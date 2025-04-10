using System.ComponentModel.DataAnnotations;

namespace TP_RestaurantReviewApp.Models
{
    public class ForgotCredentialsViewModel
    {
        private string email;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public ForgotCredentialsViewModel()
        {

        }
        
        public ForgotCredentialsViewModel(string email)
        {
            Email = email;
        }
    }
}
