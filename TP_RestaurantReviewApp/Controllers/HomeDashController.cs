using Microsoft.AspNetCore.Mvc;

namespace TP_RestaurantReviewApp.Controllers
{
    public class HomeDashController : Controller
    {
        public IActionResult Index()
        {
            
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
