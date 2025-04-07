using Microsoft.AspNetCore.Mvc;

namespace TP_RestaurantReviewApp.Controllers
{
    public class ReviewController : Controller
    {
        [HttpPost()]
        public IActionResult CreateReview()
        {
            return View();
        }
    }
}
