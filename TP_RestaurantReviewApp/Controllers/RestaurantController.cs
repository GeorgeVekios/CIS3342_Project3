using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using RestaurantDBOperations;
using ObjectClassLibrary;
using System.Diagnostics;
using DBOperationsClassLibrary;
using TP_RestaurantReviewApp.Models;
using ReviewDBOperations;
using ImageDBOperations;
using SocialMediaDBOperations;

namespace TP_RestaurantReviewApp.Controllers
{
    public class RestaurantController : Controller
    {
        [HttpGet("Restaurant/ViewRestaurantProfile/{id}")]
        // route: Restaurant/ViewRestaurantProfile/id
        public IActionResult ViewRestaurantProfile(int id)
        {
            GetRestaurantByIDOp getRestaurantByIDOp = new GetRestaurantByIDOp();
            Restaurant restaurant = getRestaurantByIDOp.GetRestaurantByID(id);

            GetReviewsByRestaurantIDOp getReviewsByRestaurantIDOp = new GetReviewsByRestaurantIDOp();
            List<Review> reviewList = getReviewsByRestaurantIDOp.GetReviewsByRestaurantID(id);

            GetImagesByRestaurantIDOp getImagesByRestaurantIDOp = new GetImagesByRestaurantIDOp();
            List<Image> imageGallery = getImagesByRestaurantIDOp.GetImagesByRestaurantID(id);

            GetSocialMediaByRestaurantIDOp getSocialMediaByRestaurantIDOp = new GetSocialMediaByRestaurantIDOp();
            List<SocialMedia> socialMediaList = getSocialMediaByRestaurantIDOp.GetSocialMediaByRestaurantID(id);

            return View(new RestaurantProfileViewModel(restaurant, reviewList, imageGallery, socialMediaList));
        }

        [HttpGet("Restaurant/SearchRestaurants")]
        // route: Restaurant/SearchRestaurants
        public IActionResult SearchRestaurants(string city, string state, List<string> cuisines)
        {
            SearchRestaurantsOp searchRestaurantsOp = new SearchRestaurantsOp();
            List<Restaurant> restaurantList = searchRestaurantsOp.SearchRestaurants(city, state, cuisines);
            
            GetAllCuisinesOp getAllCuisinesOp = new GetAllCuisinesOp();
            ViewBag.Cuisines = getAllCuisinesOp.GetAllCuisines();

            return View(new SearchRestaurantsViewModel(restaurantList));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Restaurant());
        }

        [HttpPost]
        public IActionResult Add(Restaurant restaurant)
        {
            AddRestaurantOp addRestaurantOp = new AddRestaurantOp();

            try
            {
                addRestaurantOp.AddRestaurant(restaurant);
                ViewBag.Message = "Restaurant added successfully!";
                return View(new Restaurant());
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error adding restaurant: {ex.Message}";
                return View(restaurant);
            }
        }
    }
}
