using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OurNotes.Model;

namespace OurNotes.ConsoleApplication
{
    // Пример использования модели
    class Program
    {
        static void printNote(Note note)
        {
            Console.WriteLine("[Title: {0}, Content: {1}]", note.Title, note.Content);
        }

        static void Main(string[] args)
        {
            User first = User.Manager.Register("skywalker", "farther");
            User second = User.Manager.Register("yoda", "TheForce");

            Note temp = Note.Manager.CreateNote(first, "title1", "content1");
            temp = Note.Manager.CreateNote(first, "title2", "content2");
            temp.Share(first, second, true);
            temp.Update(second, "edited title2", "edited content2");
            temp = Note.Manager.CreateNote(first, "title3", "content3");

            IList<Note> notesOfFirstUser = Note.Manager.GetNotesForUser(first);
            Console.WriteLine("Notes of user {0}", first.Username);
            foreach (Note note in notesOfFirstUser)
            {
                printNote(note);
            }

            Console.WriteLine("");

            IList<Note> notesOfSecondUser = Note.Manager.GetNotesForUser(second);
            Console.WriteLine("Notes of user {0}", second.Username);
            foreach (Note note in notesOfSecondUser)
            {
                printNote(note);
            }
        }
    }
}
