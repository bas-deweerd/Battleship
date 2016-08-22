using ServiceLibrary.Models;

namespace Client.ViewModels
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
