using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using RestaurantDBOperations;
using ObjectClassLibrary;
using System.Diagnostics;
using DBOperationsClassLibrary;

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
