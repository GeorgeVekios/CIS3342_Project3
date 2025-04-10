using System.ComponentModel.DataAnnotations;

namespace TP_RestaurantReviewApp.Models
{
    public class ResetPasswordViewModel
    {
        private int securityQuestionID;
        private string securityAnswer;
        private string newPassword;
        private string confirmNewPassword;
        private string username;

        [Required]
        public int SecurityQuestionID
        {
            get { return securityQuestionID; }
            set { securityQuestionID = value; }
        }

        [Required(ErrorMessage = "Answer is required.")]
        public string SecurityAnswer
        {
            get { return securityAnswer; }
            set { securityAnswer = value; }
        }

        [Required(ErrorMessage = "New password is required.")]
        [DataType(DataType.Password)]
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

        [Required(ErrorMessage = "Confirm new password is required.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword
        {
            get { return confirmNewPassword; }
            set { confirmNewPassword = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public ResetPasswordViewModel()
        {

        }

        public ResetPasswordViewModel(int securityQuestionID, string securityAnswer, string newPassword, string confirmNewPassword, string username)
        {
            SecurityQuestionID = securityQuestionID;
            SecurityAnswer = securityAnswer;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmNewPassword;
            Username = username;
        }
    }
}
