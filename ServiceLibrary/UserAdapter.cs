using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ServiceLibrary.Models;

namespace ServiceLibrary
{
    /// <summary>
    /// Class that contains all necessary functions to manage users.
    /// Also updates the XML file of users.
    /// </summary>
    public static class UserAdapter
    {
        private static List<User> _userList = null;
        
        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <returns>List of all existing users</returns>
        public static List<User> GetUserList()
        {
            if (_userList != null)
            {
                return _userList;
            }
            else
            {
                _userList = new List<User>();
                
                XDocument doc = XDocument.Parse(ServiceLibrary.Properties.Resources.users);
                foreach (XElement u in doc.Descendants("user"))
                {
                    _userList.Add(new User((String)u.Element("email"), (String)u.Element("password")));
                }
                return _userList;
            }


        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="email">The username.</param>
        /// <param name="password">The password.</param>
        public static void Register(String email, String password)
        {
            User user = new User(email, password);
            if (_userList == null)
            {
                GetUserList();
            }
            _userList.Add(user);
            
            XDocument doc = XDocument.Parse(Properties.Resources.users);
            XElement xmluser = new XElement("user");
            xmluser.Add(new XElement("email", email), new XElement("password", password));
            doc.Root.Add(xmluser);

            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "../../../Resources/users.xml");
        }

        /// <summary>
        /// Validates if the credentials are correct.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns true if credentials are correct, otherwise returns false.</returns>
        public static bool CredentialsCorrect(String email, String password)
        {
            return GetUserList().Any(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public static void RemoveUser(String email, String password)
        {
            if (!CredentialsCorrect(email, password))
            {
                return;
            }
            RemoveUser(email);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="email">The email.</param>
        private static void RemoveUser(String email)
        {
            XDocument doc = XDocument.Parse(ServiceLibrary.Properties.Resources.users);
            XNode current = doc.Root.FirstNode;
            //Console.WriteLine(current.ToString());
            //TODO
            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "../../../Resources/users.xml");
        }

        /// <summary>
        /// Empties the user list.
        /// </summary>
        public static void EmptyUserList()
        {
            XDocument doc = XDocument.Parse(ServiceLibrary.Properties.Resources.users);
            doc.Root.RemoveNodes();
            doc.Save(AppDomain.CurrentDomain.BaseDirectory + "../../../Resources/users.xml");
        }

        /// <summary>
        /// Determines whether there are any users.
        /// </summary>
        /// <returns></returns>
        public static bool IsEmpty()
        {
            XDocument doc = XDocument.Parse(ServiceLibrary.Properties.Resources.users);
            return doc.Root.IsEmpty;
        }
    }
}
