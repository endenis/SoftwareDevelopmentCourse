using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurNotes.Model
{
    public class NoteException : Exception
    {
        public User User
        {
            get;
            protected set;
        }

        public Note Note
        {
            get;
            protected set;
        }

        public NoteException(User user, Note note, string message = "")
            : base(message)
        {
            this.User = user;
            this.Note = note;
        }
    }

    // Исключение "Этот пользователь не может редактировать эту заметку"
    public class NotEditableNoteException : NoteException
    {
        public NotEditableNoteException(User user, Note note)
            : base(user, note, "This note is not editable for this user")
        {
        }
    }

    // Исключение "Этот пользователь не является владельцем этой заметки"
    public class NotOwnerOfNoteException : NoteException
    {
        public NotOwnerOfNoteException(User user, Note note)
            : base(user, note, "This user is not owner of this note")
        {
        }
    }
}
