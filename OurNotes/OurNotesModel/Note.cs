using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurNotes.Model
{
    public class Note
    {
        public class Manager
        {
            // Коллекция всех заметок системы
            protected static IList<Note> notes = new List<Note>();

            // Поиск всех заметок, которые видны пользователю
            public static IList<Note> GetNotesForUser(User user)
            {
                List<Note> notesOfUser = new List<Note>();
                foreach (Note note in notes)
                {
                    if (note.readers.Contains(user) || note.editors.Contains(user) || note.owner.Equals(user))
                    {
                        notesOfUser.Add(note);
                    }
                }
                return notesOfUser;
            }

            // Создание заметки
            public static Note CreateNote(User user, string title = "", string content = "")
            {
                Note note = new Note(user, title, content);
                notes.Add(note);
                return note;
            }
        }

        public string Title
        {
            get;
            protected set;
        }

        public string Content
        {
            get;
            protected set;
        }

        protected IList<User> readers = new List<User>();
        protected IList<User> editors = new List<User>();
        protected User owner;

        protected Note(User user, string title = "", string content = "")
        {
            owner = user;
            Title = title;
            Content = content;
        }

        // Может ли пользователь редактировать заметку
        public bool IsEditableFor(User user)
        {
            return (editors.Contains(user) || owner.Equals(user));
        }

        // Изменение названия и содержимого заметки пользователем.
        public void Update(User user, string title, string content)
        {
            if (!IsEditableFor(user))
            {
                throw new NotEditableNoteException(user, this);
            }
            Title = title;
            Content = content;
        }

        // Поделиться заметкой пользователя другому пользователю с указанием, сможет ли другой пользователь её редактировать.
        public void Share(User fromUser, User toUser, bool shouldBeAbleToEdit)
        {
            if (!owner.Equals(fromUser))
            {
                throw new NotOwnerOfNoteException(fromUser, this);
            }

            if (shouldBeAbleToEdit)
            {
                if (!editors.Contains(toUser))
                {
                    editors.Add(toUser);
                }
            }
            else
            {
                if (!readers.Contains(toUser))
                {
                    readers.Add(toUser);
                }
            }
        }
    }
}
