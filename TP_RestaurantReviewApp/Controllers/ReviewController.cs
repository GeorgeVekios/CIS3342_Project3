using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObjectClassLibrary;
using RestaurantDBOperations;
using System.Diagnostics;
using TP_RestaurantReviewApp.Models;

namespace TP_RestaurantReviewApp.Controllers
{
    public class ReviewController : Controller
    {

        private HttpClient httpClient;
        private string apiBaseURL = "https://localhost:7105/api/Review";

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult CreateReview()
        {
            GetAllRestaurantsOp getAllRestaurantsOp = new GetAllRestaurantsOp();
            List<Restaurant> restaurantList = getAllRestaurantsOp.GetAllRestaurants();

            ViewBag.RestaurantList = restaurantList.Select(r => new SelectListItem
            {
                Value = r.RestaurantID.ToString(),
                Text = r.Name
            }).ToList();

            var model = new CreateReviewViewModel
            {
                Review = new Review
                {
                    CreatedAt = DateTime.Now
                }
            };
            return View();
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

                if (TempData.ContainsKey("EditingReviewID"))
                {
                    ViewBag.EditingReviewID = TempData["EditingReviewID"];
                }
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
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            Debug.WriteLine("Trying to fetch ReviewID: " + review.ReviewID);

            HttpResponseMessage response = await httpClient.PutAsJsonAsync(apiBaseURL + "/" + review.ReviewID, review);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ManageReviews", new { userID = review.UserID });
            }

            ModelState.AddModelError("", "Failed to update review via API");
            return View(review);
        }

        [HttpGet]
        public IActionResult Edit(int reviewID, int userID)
        {
            TempData["EditingReviewID"] = reviewID;
            return RedirectToAction("ManageReviews", new { userID = userID });
            //HttpResponseMessage response = await httpClient.GetAsync(apiBaseURL + "/byID/" + reviewID);
            //if (response.IsSuccessStatusCode)
            //{
            //    Review review = await response.Content.ReadFromJsonAsync<Review>();
            //    return View(review);
            //}

            //return NotFound();
        }

        [HttpGet]
        public IActionResult Cancel(int reviewID, int userID)
        {
            return RedirectToAction("ManageReviews", new { userID = userID });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int reviewID, int userID)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(apiBaseURL + "/" + reviewID);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ManageReviews", new { userID = userID });
            }

            TempData["Error"] = "Failed to delete review via API";
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
