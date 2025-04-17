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
            string passwordFromCookie = Request.Cookies["LoginPassword"];
            if (usernameFromCookie != null && usernameFromCookie != "" && passwordFromCookie != null && passwordFromCookie != "")
            {
                model.Username = usernameFromCookie;
                model.Password = passwordFromCookie;
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
                        Response.Cookies.Append("LoginPassword", model.Password);
                    }
                    else
                    {
                        Response.Cookies.Delete("LoginUsername");
                    }
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("UserType", user.UserType);
                    return RedirectToAction("Index", "Home");
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
                    CreatedAt = DateTime.Now,
                    IsVerified = false,
                    SecurityRecord1 = 0,
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

        [HttpGet()]
        public IActionResult ForgotUsername()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult ForgotUsername(string email)
        {
            GetUserByEmailOp getUserByEmailOp = new GetUserByEmailOp();
            User user = getUserByEmailOp.GetUserByEmail(email);

            if (user != null)
            {
                string subject = "Your Forgotten Username";
                string body = $"Dear {user.FirstName},\n\nYour username is: {user.Username}\n\nIf you didn't request this, please ignore this email.";

                Email emailSender = new Email();
                emailSender.SendMail(user.Email, "support@forkscore.com", subject, body);

                TempData["Message"] = "Your username has been sent to your email.";
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Email not found.");
            }

            return View();
        }

        [HttpGet()]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult ForgotPassword(string email)
        {
            GetUserByEmailOp getUserByEmailOp = new GetUserByEmailOp();
            User user = getUserByEmailOp.GetUserByEmail(email);

            if (user != null)
            {
                string token = Guid.NewGuid().ToString();
                TempData["ResetToken"] = token;
                TempData["UserID"] = user.UserID;

                string resetLink = Url.Action("ResetPassword", "Account", new { token = token }, protocol: Request.Scheme);
                string subject = "Password Reset Request";
                string body = $"Dear {user.FirstName},\n\nTo reset your password, click on the link below:\n{resetLink}\n\nIf you didn't request this, please ignore this email.";

                Email emailSender = new Email();
                emailSender.SendMail(user.Email, "support@forkscore.com", subject, body);

                TempData["Message"] = "A password reset link has been sent to your email.";
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Email not found.");
            }

            return View();
        }

        [HttpGet()]
        public IActionResult ResetPassword(string token)
        {
            if (token == TempData["ResetToken"]?.ToString())
            {
                return View();
            }
            else
            {
                TempData["Message"] = "Invalid or expired reset token.";
                return RedirectToAction("Login");
            }
        }

        [HttpPost()]
        public IActionResult ResetPassword(string token, string newPassword)
        {
            if (token == TempData["ResetToken"]?.ToString())
            {
                int userID = (int)TempData["UserID"];
                UpdateUserPasswordOp updateUserPasswordOp = new UpdateUserPasswordOp();
                updateUserPasswordOp.UpdateUserPassword(userID, newPassword);

                TempData["Message"] = "Your password has been reset successfully.";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Message"] = "Invalid or expired reset token.";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
