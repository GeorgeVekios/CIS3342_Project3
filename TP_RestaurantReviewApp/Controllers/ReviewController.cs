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

        [HttpGet()]
        public IActionResult ManageReviews(int userID)
        {
            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(userID);

            ManageReviewsViewModel model = new ManageReviewsViewModel
            {
                ReviewList = reviewList
            };
            return View(model);
        }

        [HttpGet()]
        public IActionResult Edit(int id, int userID)
        {
            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(userID);

            ManageReviewsViewModel model = new ManageReviewsViewModel
            {
                ReviewList = reviewList
            };
            ViewBag.EditingReviewId = id;
            return View("ManageReviews", model);
        }

        [HttpPost()]
        public IActionResult Update(Review review)
        {
            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(review.UserID);

            ManageReviewsViewModel model = new ManageReviewsViewModel
            {
                ReviewList = reviewList
            };

            UpdateReviewOp updateReviewOp = new UpdateReviewOp();
            updateReviewOp.UpdateReview(review);
            return RedirectToAction("ManageReviews");
        }

        [HttpGet()]
        public IActionResult Delete(Review review)
        {
            DeleteReviewOp deleteReviewOp = new DeleteReviewOp();
            deleteReviewOp.DeleteReview(review.ReviewID);
            return RedirectToAction("ManageReviews");
        }

        [HttpGet()]
        public IActionResult Cancel()
        {
            return RedirectToAction("ManageReviews");
        }


    }
}
