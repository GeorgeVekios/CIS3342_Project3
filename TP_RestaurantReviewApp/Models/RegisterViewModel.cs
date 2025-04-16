using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace TP_RestaurantReviewApp.Models
{
    public class RegisterViewModel
    {
        private string username;
        private string userType;
        private string email;
        private string password;
        private string confirmPassword;
        private string firstName;
        private string lastName;
        private string phoneNum;
        private List<SelectListItem> securityQuestions;

        private int securityQuestion1ID;
        private string answer1;
        private int securityQuestion2ID;
        private string answer2;
        private int securityQuestion3ID;
        private string answer3;

        [Required(ErrorMessage = "Username is required")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Please select a role")]
        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password 
        { 
            get { return password; }
            set { password = value; }
        }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        [BindNever]
        [ValidateNever]
        public List<SelectListItem> SecurityQuestions
        {
            get { return securityQuestions; }
            set { securityQuestions = value; }
        }

        [Required]
        public int SecurityQuestion1ID
        {
            get { return securityQuestion1ID; }
            set { securityQuestion1ID = value; }
        }

        [Required]
        public string Answer1
        {
            get { return answer1; }
            set { answer1 = value; }
        }

        [Required]
        public int SecurityQuestion2ID
        {
            get { return securityQuestion2ID; }
            set { securityQuestion2ID = value; }
        }

        [Required]
        public string Answer2
        {
            get { return answer2; }
            set { answer2 = value; }
        }

        [Required]
        public int SecurityQuestion3ID
        {
            get { return securityQuestion3ID; }
            set { securityQuestion3ID = value; }
        }

        [Required]
        public string Answer3
        {
            get { return answer3; }
            set { answer3 = value; }
        }
        public RegisterViewModel()
        {
           
        }

        public RegisterViewModel(string username, string userType, string email, string password, string confirmPassword, string firstName, string lastName, string phoneNum, List<SelectListItem> securityQuestions, int securityQuestion1ID, string answer1, int securityQuestion2ID, string answer2, int securityQuestion3ID, string answer3)
        {
            Username = username;
            UserType = userType;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            FirstName = firstName;
            LastName = lastName;
            PhoneNum = phoneNum;
            SecurityQuestions = securityQuestions;
            SecurityQuestion1ID = securityQuestion1ID;
            Answer1 = answer1;
            SecurityQuestion2ID = securityQuestion2ID;
            Answer2 = answer2;
            SecurityQuestion3ID = securityQuestion3ID;
            Answer3 = answer3;
        }
    }
}
