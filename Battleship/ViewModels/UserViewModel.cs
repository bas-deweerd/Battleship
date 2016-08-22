using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Battleship.Annotations;
using Battleship.Models;

namespace Battleship.ViewModels
{
    internal class UserViewModel
    {
        private User _user;

        public User user
        {
            get{
                return _user;
            }
        }

        public UserViewModel()
        {
            _user = new User("email", "pass");
        }

        public User User()
        {
            return _user;
        }

    }
}
