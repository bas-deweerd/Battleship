using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ServiceLibrary.Models
{
    /// <summary>
    /// Users of the game.
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; 
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="email">The email, used as the username.</param>
        /// <param name="password">The password.</param>
        public User(String email, String password)
        {
            this.Email = email;
            this.Password = password;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
