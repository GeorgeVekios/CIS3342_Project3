using System.ComponentModel.DataAnnotations;

namespace TP_RestaurantReviewApp.Models
{
    public class LoginViewModel
    {
        private string username;
        private string password;
        private bool rememberMe;

        [Required(ErrorMessage = "Username is required.")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }

        public LoginViewModel()
        {

        }

        public LoginViewModel(string username, string password, bool rememberMe)
        {
            Username = username;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
