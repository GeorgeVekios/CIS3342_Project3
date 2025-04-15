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

        private HttpClient httpClient;
        private string apiBaseURL = "http://localhost:5184/api/ReviewAPI";

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(Review review)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiBaseURL, review);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ManageReviews", new { userID = review.UserID });
            }

            ModelState.AddModelError("", "Failed to create review via API");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ManageReviews(int userID)
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseURL + "/" + userID);
            if (response.IsSuccessStatusCode)
            {
                List<Review> reviews = await response.Content.ReadFromJsonAsync<List<Review>>();
                ManageReviewsViewModel model = new ManageReviewsViewModel
                {
                    ReviewList = reviews
                };
                return View(model);
            }

            ManageReviewsViewModel emptyModel = new ManageReviewsViewModel
            {
                ReviewList = new List<Review>()
            };
            return View(emptyModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Review review)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(apiBaseURL, review);
            return RedirectToAction("ManageReviews", new { userID = review.UserID });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int reviewID, int userID)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(apiBaseURL + "/" + reviewID);
            return RedirectToAction("ManageReviews", new { userID = userID });
        }
    }
}

//        [HttpGet()]
//        public IActionResult CreateReview()
//        {
//            GetAllRestaurantsOp getAllRestaurantsOp = new GetAllRestaurantsOp();
//            List<Restaurant> restaurants = getAllRestaurantsOp.GetAllRestaurants();

//            List<SelectListItem> restaurantList = new List<SelectListItem>();

//            foreach (Restaurant restaurant in restaurants)
//            {
//                SelectListItem item = new SelectListItem();
//                item.Value = restaurant.RestaurantID.ToString();
//                item.Text = restaurant.Name;
//                restaurantList.Add(item);
//            }

//            ViewBag.RestaurantList = restaurantList;

//            CreateReviewViewModel model = new CreateReviewViewModel
//            {
//                Review = new Review { CreatedAt = DateTime.Now }
//            };

//            return View(model);
//        }

//        [HttpPost()]
//        public IActionResult CreateReview(Review review)
//        {
//            GetAllRestaurantsOp getAllRestaurantsOp = new GetAllRestaurantsOp();
//            List<Restaurant> restaurants = getAllRestaurantsOp.GetAllRestaurants();

//            List<SelectListItem> restaurantList = new List<SelectListItem>();

//            foreach (Restaurant restaurant in restaurants)
//            {
//                SelectListItem item = new SelectListItem();
//                item.Value = restaurant.RestaurantID.ToString();
//                item.Text = restaurant.Name;
//                restaurantList.Add(item);
//            }

//            ViewBag.RestaurantList = restaurantList;

//            CreateReviewViewModel model = new CreateReviewViewModel
//            {
//                Review = new Review { CreatedAt = DateTime.Now }
//            };

//            AddReviewOp addReviewOp = new AddReviewOp();
//            addReviewOp.AddReview(review);

//            return View(model);
//        }

//        [HttpGet()]
//        public IActionResult ManageReviews(int userID)
//        {
//            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
//            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(userID);

//            ManageReviewsViewModel model = new ManageReviewsViewModel
//            {
//                ReviewList = reviewList
//            };
//            return View(model);
//        }

//        [HttpGet()]
//        public IActionResult Edit(int id, int userID)
//        {
//            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
//            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(userID);

//            ManageReviewsViewModel model = new ManageReviewsViewModel
//            {
//                ReviewList = reviewList
//            };
//            ViewBag.EditingReviewId = id;
//            return View("ManageReviews", model);
//        }

//        [HttpPost()]
//        public IActionResult Update(Review review)
//        {
//            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
//            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(review.UserID);

//            ManageReviewsViewModel model = new ManageReviewsViewModel
//            {
//                ReviewList = reviewList
//            };

//            UpdateReviewOp updateReviewOp = new UpdateReviewOp();
//            updateReviewOp.UpdateReview(review);
//            return RedirectToAction("ManageReviews");
//        }

//        [HttpGet()]
//        public IActionResult Delete(Review review)
//        {
//            DeleteReviewOp deleteReviewOp = new DeleteReviewOp();
//            deleteReviewOp.DeleteReview(review.ReviewID);
//            return RedirectToAction("ManageReviews");
//        }

//        [HttpGet()]
//        public IActionResult Cancel()
//        {
//            return RedirectToAction("ManageReviews");
//        }


//    }
//}
