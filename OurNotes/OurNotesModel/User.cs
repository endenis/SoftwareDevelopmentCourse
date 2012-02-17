using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurNotes.Model
{
    public class User : IEquatable<User>
    {
        public class Manager
        {
            // Коллекция всех пользователй системы
            protected static IList<User> users = new List<User>();

            // Регистрация пользователей
            public static User Register(string username, string password)
            {
                // Проверка, есть ли пользователь с таким именем
                foreach (User user in users)
                {
                    if (user.Username == username)
                    {
                        return null;
                    }
                }

                // Создание пользователя
                User userToRegister = new User(username, password);
                users.Add(userToRegister);
                return userToRegister;
            }

            // Аунтентификация пользователя
            public static User Authenticate(string username, string password)
            {
                User userToAuthenticate = null;
                foreach (User user in users)
                {
                    if (user.Username == username)
                    {
                        if (user.Password == password)
                        {
                            userToAuthenticate = user;
                        }
                        break;
                    }
                }
                return userToAuthenticate;
            }

            // Поиск пользователя в коллекции всех пользователей системы
            public static User GetUser(string username)
            {
                User userToGet = null;
                foreach (User user in users)
                {
                    if (user.Username == username)
                    {
                        userToGet = user;
                        break;
                    }
                }
                return userToGet;
            }
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool Equals(User other)
        {
            bool result = false;
            if (other.Username == Username)
            {
                result = true;
            }
            return result;
        }

        protected User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
