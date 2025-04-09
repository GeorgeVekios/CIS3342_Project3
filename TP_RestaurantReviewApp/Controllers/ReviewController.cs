using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectClassLibrary;
using RestaurantDBOperations;
using ReviewDBOperations;
using TP_RestaurantReviewApp.Models;

namespace TP_RestaurantReviewApp.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet()]
        public IActionResult CreateReview()
        {
            GetAllRestaurantsOp getAllRestaurantsOp = new GetAllRestaurantsOp();
            List<Restaurant> restaurants = getAllRestaurantsOp.GetAllRestaurants();

            List<SelectListItem> restaurantList = new List<SelectListItem>();

            foreach (Restaurant restaurant in restaurants)
            {
                SelectListItem item = new SelectListItem();
                item.Value = restaurant.RestaurantID.ToString();
                item.Text = restaurant.Name;
                restaurantList.Add(item);
            }

            ViewBag.RestaurantList = restaurantList;

            CreateReviewViewModel model = new CreateReviewViewModel
            {
                Review = new Review { CreatedAt = DateTime.Now }
            };

            return View(model);
        }

        [HttpPost()]
        public IActionResult CreateReview(Review review)
        {
            GetAllRestaurantsOp getAllRestaurantsOp = new GetAllRestaurantsOp();
            List<Restaurant> restaurants = getAllRestaurantsOp.GetAllRestaurants();

            List<SelectListItem> restaurantList = new List<SelectListItem>();

            foreach (Restaurant restaurant in restaurants)
            {
                SelectListItem item = new SelectListItem();
                item.Value = restaurant.RestaurantID.ToString();
                item.Text = restaurant.Name;
                restaurantList.Add(item);
            }

            ViewBag.RestaurantList = restaurantList;

            CreateReviewViewModel model = new CreateReviewViewModel
            {
                Review = new Review { CreatedAt = DateTime.Now }
            };

            AddReviewOp addReviewOp = new AddReviewOp();
            addReviewOp.AddReview(review);

            return View(model);
        }
    }
}
