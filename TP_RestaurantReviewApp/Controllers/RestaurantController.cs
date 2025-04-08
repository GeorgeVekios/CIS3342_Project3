using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using RestaurantDBOperations;
using ObjectClassLibrary;
using System.Diagnostics;
using DBOperationsClassLibrary;
using TP_RestaurantReviewApp.Models;

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
            return View(restaurant);
        }

        [HttpGet("Restaurant/SearchRestaurants")]
        // route: Restaurant/SearchRestaurants
        public IActionResult SearchRestaurants(string city, string state, List<string> cuisines)
        {
            SearchRestaurantsOp searchRestaurantsOp = new SearchRestaurantsOp();
            List<Restaurant> restaurantList = searchRestaurantsOp.SearchRestaurants(city, state, cuisines);
            
            GetAllCuisinesOp getAllCuisinesOp = new GetAllCuisinesOp();
            ViewBag.Cuisines = getAllCuisinesOp.GetAllCuisines();
            return View("SearchRestaurants", restaurantList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new CreateRestaurantPageViewModel { Restaurant = new Restaurant() };
            return View(viewModel);
        }

        [HttpPost]
        //ownerId will be passed as UserID in cookie
        public IActionResult CreateRestaurantPage(CreateRestaurantPageViewModel viewModel, int OwnerID)
        {
            AddRestaurantOp addRestaurantOp = new AddRestaurantOp();
            Restaurant restaurant = viewModel.Restaurant;
            try
            {
                addRestaurantOp.AddRestaurant(restaurant);
                ViewBag.Message = "Restaurant added successfully!";
                return View(new Restaurant());
            }
            catch (Exception ex)
            {
                viewModel.Message = $"Error adding restaurant: {ex.Message}";
                return View(viewModel);
            }
        }
    }
}
