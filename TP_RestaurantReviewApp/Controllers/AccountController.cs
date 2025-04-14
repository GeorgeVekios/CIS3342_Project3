using DBOperationsClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectClassLibrary;
using TP_RestaurantReviewApp.Models;
using UserDBOperations;
using Utilities;

namespace TP_RestaurantReviewApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet()]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            string usernameFromCookie = Request.Cookies["LoginUsername"];
            
            if (usernameFromCookie != null && usernameFromCookie != "")
            {
                model.Username = usernameFromCookie;
            }
            return View(model);
        }

        [HttpPost()]
        public IActionResult Login(LoginViewModel model)
        {
            GetUserByUsernameOp getUserByUsernameOp = new GetUserByUsernameOp();
            if (ModelState.IsValid)
            {
                User user = getUserByUsernameOp.GetUserByUsername(model.Username);

                if (user != null && user.Password == model.Password)
                {
                    if (model.RememberMe)
                    {
                        Response.Cookies.Append("LoginUsername", model.Username);
                    }
                    else
                    {
                        Response.Cookies.Delete("LoginUsername");
                    }
                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    return RedirectToAction("Dashboard", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }

        [HttpGet()]
        public IActionResult Register()
        {
            GetAllSecurityQuestionsOp getAllSecurityQuestionsOp = new GetAllSecurityQuestionsOp();
            List<SecurityQuestion> securityQuestions = getAllSecurityQuestionsOp.GetAllSecurityQuestions();

            RegisterViewModel model = new RegisterViewModel();

            model.SecurityQuestions = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var securityQuestion in securityQuestions)
            {
                {
                    model.SecurityQuestions.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = securityQuestion.QuestionText, Value = securityQuestion.SecurityQuestionID.ToString() });
                }
            }
            return View(model);
        }

        [HttpPost()]
        public IActionResult Register(RegisterViewModel model)
        {
            DoesUsernameExistOp doesUsernameExistOp = new DoesUsernameExistOp();
            DoesEmailExistOp doesEmailExistOp = new DoesEmailExistOp();
            if (ModelState.IsValid)
            {
                if (doesUsernameExistOp.DoesUsernameExist(model.Username))
                {
                    ModelState.AddModelError("Username", "Username already taken.");
                    return View(model);
                }

                if (doesEmailExistOp.DoesEmailExist(model.Email))
                {
                    ModelState.AddModelError("Email", "Email already registered.");
                    return View(model);
                }

                User newUser = new User
                {
                    Username = model.Username,
                    UserType = model.UserType,
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNum = string.IsNullOrEmpty(model.PhoneNum) ? "N/A" : model.PhoneNum, // Default if null
                    CreatedAt = DateTime.Now, // Set explicitly
                    IsVerified = false,
                    SecurityRecord1 = 0, // Temporary, to be updated later
                    SecurityRecord2 = 0,
                    SecurityRecord3 = 0
                };

                try
                {
                    RegisterUserOp registerUserOp = new RegisterUserOp();
                    int newUserID = registerUserOp.RegisterUser(newUser);

                    SaveSecurityAnswerOp saveSecurityAnswerOp = new SaveSecurityAnswerOp();
                    InsertSecurityAnswerIntoUserTableOp insertSecurityAnswerIntoUserTableOp = new InsertSecurityAnswerIntoUserTableOp();

                    int question1 = saveSecurityAnswerOp.SaveUserSecurityAnswer(newUserID, model.SecurityQuestion1ID, model.Answer1);
                    insertSecurityAnswerIntoUserTableOp.InsertSecurityAnswerIntoUserTable(newUserID, question1, 1);
                    int question2 = saveSecurityAnswerOp.SaveUserSecurityAnswer(newUserID, model.SecurityQuestion2ID, model.Answer2);
                    insertSecurityAnswerIntoUserTableOp.InsertSecurityAnswerIntoUserTable(newUserID, question2, 2);
                    int question3 = saveSecurityAnswerOp.SaveUserSecurityAnswer(newUserID, model.SecurityQuestion3ID, model.Answer3);
                    insertSecurityAnswerIntoUserTableOp.InsertSecurityAnswerIntoUserTable(newUserID, question3, 3);

                    string code = GenerateVerificationCode();
                    TempData["VerificationCode"] = code;
                    TempData["UserID"] = newUserID;

                    Email verificationEmail = new Email();

                    string emailBody = "Dear " + newUser.FirstName + ",<br /><br />" +
                   "Thank you for registering with ForkScore! To complete your account setup, please verify your email address using the code below:<br /><br />" +
                   "<strong>Verification Code: " + code + "</strong><br /><br />" +
                   "Enter this code on the verification page to activate your account. For security, this code will expire in 24 hours.<br /><br />" +
                   "If you didn’t initiate this registration, please ignore this email or contact our support team at support@forkscore.com.<br /><br />" +
                   "Welcome to ForkScore!<br />" +
                   "The ForkScore Team";

                    verificationEmail.SendMail(newUser.Email, "tuo77176@temple.edu", "ForkScore - Verification Code", emailBody);
                    return RedirectToAction("Verify");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Registration failed: {ex.Message}");
                }
            }
            model.SecurityQuestions = GetSecurityQuestionList();
            return View(model);
        }

        [HttpGet()]
        public IActionResult Verify()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Verify(string inputCode)
        {
            string actualCode = TempData["VerificationCode"] as string;
            int userID = (int)TempData["UserID"];

            MarkUserAsVerifiedOp markUserAsVerifiedOp = new MarkUserAsVerifiedOp();
            if (inputCode == actualCode)
            {
                markUserAsVerifiedOp.MarkUserAsVerified(userID);
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Incorrect verification code");
            return View();
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private List<SelectListItem> GetSecurityQuestionList()
        {
            GetAllSecurityQuestionsOp getAllSecurityQuestionsOp = new GetAllSecurityQuestionsOp();
            var questions = getAllSecurityQuestionsOp.GetAllSecurityQuestions();

            return questions.Select(q => new SelectListItem
            {
                Text = q.QuestionText,
                Value = q.SecurityQuestionID.ToString()
            }).ToList();
        }
    }
}
