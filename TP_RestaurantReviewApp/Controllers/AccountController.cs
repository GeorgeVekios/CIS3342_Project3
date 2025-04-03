using Microsoft.AspNetCore.Mvc;
using TP_RestaurantReviewApp.Models;
using System.Data.SqlClient;

namespace TP_RestaurantReviewApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register (User user)
        {

        }

    }
}
