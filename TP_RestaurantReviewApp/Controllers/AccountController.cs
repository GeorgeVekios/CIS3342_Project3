using DBOperationsClassLibrary;
using Microsoft.AspNetCore.Mvc;
using ObjectClassLibrary;
using TP_RestaurantReviewApp.Models;
using UserDBOperations;

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
                User user = new User();
                //User user = getUserByUsernameOp.GetUserByUsername(model.Username);

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

        //[HttpGet()]
        //public IActionResult Register()
        //{
        //    GetAllSecurityQuestionsOp getAllSecurityQuestionsOp = new GetAllSecurityQuestionsOp();
        //    List<SecurityQuestion> securityQuestions = getAllSecurityQuestionsOp.GetAllSecurityQuestions();

        //    RegisterViewModel model = new RegisterViewModel();

        //    model.SecurityQuestions = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        //    foreach (var securityQuestion in securityQuestions) {
        //        {
        //            model.Sec
        //        }
        //    }

        //}
    }
}
