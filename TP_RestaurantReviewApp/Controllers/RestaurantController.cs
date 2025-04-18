﻿using Microsoft.AspNetCore.Mvc;
using RestaurantDBOperations;
using ObjectClassLibrary;
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

        [HttpGet("Restaurant/CreateRestaurantPage")]
        public IActionResult CreateRestaurantPage()
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

        public IActionResult ManageRestaurantPage(int restaurantId)
        {
            //placeholder - need to make db operation to fetch restaurant by restaurantId
            var restaurant = new Restaurant();

            var model = new ManageRestaurantPageViewModel
            {
                Restaurant = restaurant
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageRestaurantPage(ManageRestaurantPageViewModel viewModel)
        {
            UpdateRestaurantOp updateRestaurantOp = new UpdateRestaurantOp();
            if (ModelState.IsValid)
            {
                // Update restaurant in DB
                updateRestaurantOp.UpdateRestaurant(viewModel.Restaurant);
                viewModel.Message = "Successfully Updated Restaurant";
            }
            return View(viewModel);
        }

    }
}
