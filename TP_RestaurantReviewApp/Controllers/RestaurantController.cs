using Microsoft.AspNetCore.Mvc;
using TP_RestaurantReviewApp.Models;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using System.Diagnostics;

namespace TP_RestaurantReviewApp.Controllers
{
    public class RestaurantController : Controller
    {
        [HttpGet("Restaurant/ViewRestaurantProfile/{id}")]
        // route: Restaurant/ViewRestaurantProfile/id
        public IActionResult ViewRestaurantProfile(int id)
        {
            Restaurant restaurant = new Restaurant();
            DBConnect dBConnect = new DBConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetRestaurantByID";

            cmd.Parameters.AddWithValue("@RestaurantID", id);

            DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow record = ds.Tables[0].Rows[0];

                restaurant.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
                restaurant.OwnerID = Convert.ToInt32(record["OwnerID"]);
                restaurant.Name = record["Name"].ToString();
                restaurant.Cuisine = record["Cuisine"].ToString();
                restaurant.StreetAddress = record["StreetAddress"].ToString();
                restaurant.City = record["City"].ToString();
                restaurant.State = record["State"].ToString();
                restaurant.ZipCode = Convert.ToInt32(record["ZipCode"]);
                restaurant.HoursOfOperation = record["HoursOfOperation"].ToString();
                restaurant.Email = record["Email"].ToString();
                restaurant.PhoneNum = record["PhoneNumber"].ToString();
                restaurant.Description = record["Description"].ToString();
                restaurant.OverallRating = Convert.ToDouble(record["OverallRating"]);
                restaurant.AvgFoodRating = Convert.ToDouble(record["AvgFoodRating"]);
                restaurant.AvgServiceRating = Convert.ToDouble(record["AvgServiceRating"]);
                restaurant.AvgAtmosphereRating = Convert.ToDouble(record["AvgAtmosphereRating"]);
                restaurant.AvgPriceRating = Convert.ToDouble(record["AvgPriceRating"]);
                restaurant.WebsiteURL = record["WebsiteURL"].ToString();
            }
            return View(restaurant);
        }

        [HttpGet("Restaurant/SearchRestaurants")]
        // route: Restaurant/SearchRestaurants
        public IActionResult SearchRestaurants(string city, string state, List<string> cuisines)
        {
            Debug.WriteLine($"Received city: '{city}'");
            Debug.WriteLine($"Received state: '{state}'");
            Debug.WriteLine($"Received cuisines: '{string.Join(",", cuisines ?? new List<string>())}'");
            string cleanCity;
            string cleanState;

            if (string.IsNullOrWhiteSpace(city))
            {
                cleanCity = null;
                Debug.WriteLine("City input is null or whitespace");
            }
            else
            {
                cleanCity = city.Trim();
                Debug.WriteLine($"City input after trim: '{cleanCity}'");
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                cleanState = null;
                Debug.WriteLine("State input is null or whitespace");
            }
            else
            {
                cleanState = state.Trim();
                Debug.WriteLine($"State input after trim: '{cleanState}'");
            }

            bool isSearch = !string.IsNullOrEmpty(cleanCity) || !string.IsNullOrEmpty(cleanState) || (cuisines != null && cuisines.Any());
            Debug.WriteLine($"IsSearch: {isSearch}");
            List<Restaurant> restaurantList = new List<Restaurant>();

            if (isSearch)
            {
                string cuisineList = null;

                if (cuisines != null && cuisines.Count > 0)
                {
                    cuisineList = string.Join(",", cuisines);
                    Debug.WriteLine($"Cuisine list: '{cuisineList}'");
                } 
                else
                {
                    cuisineList = null;
                    Debug.WriteLine("No cuisines provided");
                }

                DBConnect dBConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_SearchRestaurants";

                if (cleanCity == null)
                {
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                    Debug.WriteLine("Passing DBNull.Value for @City");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@City", cleanCity);
                    Debug.WriteLine($"Passing @City: '{cleanCity}'");
                }

                if (cleanState == null)
                {
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                    Debug.WriteLine("Passing DBNull.Value for @State");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@State", cleanState);
                    Debug.WriteLine($"Passing @State: '{cleanState}'");

                }

                if (cuisineList == null)
                {
                    cmd.Parameters.AddWithValue("@CuisineList", DBNull.Value);
                    Debug.WriteLine("Passing DBNull.Value for @CuisineList");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CuisineList", cuisineList);
                    Debug.WriteLine($"Passing @CuisineList: '{cuisineList}'");
                }

                DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);
                Debug.WriteLine($"Rows returned from database: {ds.Tables[0].Rows.Count}");

                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    Debug.WriteLine($"Found restaurant: {record["Name"]} in {record["City"]}, {record["State"]}");
                    Restaurant restaurant = new Restaurant();

                    restaurant.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
                    restaurant.OwnerID = Convert.ToInt32(record["OwnerID"]);
                    restaurant.Name = record["Name"].ToString();
                    restaurant.Cuisine = record["Cuisine"].ToString();
                    restaurant.StreetAddress = record["StreetAddress"].ToString();
                    restaurant.City = record["City"].ToString();
                    restaurant.State = record["State"].ToString();
                    restaurant.ZipCode = Convert.ToInt32(record["ZipCode"]);
                    restaurant.HoursOfOperation = record["HoursOfOperation"].ToString();
                    restaurant.Email = record["Email"].ToString();
                    restaurant.PhoneNum = record["PhoneNumber"].ToString();
                    restaurant.Description = record["Description"].ToString();
                    restaurant.OverallRating = Convert.ToDouble(record["OverallRating"]);
                    restaurant.AvgFoodRating = Convert.ToDouble(record["AvgFoodRating"]);
                    restaurant.AvgServiceRating = Convert.ToDouble(record["AvgServiceRating"]);
                    restaurant.AvgAtmosphereRating = Convert.ToDouble(record["AvgAtmosphereRating"]);
                    restaurant.AvgPriceRating = Convert.ToDouble(record["AvgPriceRating"]);
                    restaurant.WebsiteURL = record["WebsiteURL"].ToString();

                    restaurantList.Add(restaurant);
                }
            }
            else
            {
                Debug.WriteLine("No search parameters provided, using TP_GetAllRestaurants");
                DBConnect dBConnect = new DBConnect();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_GetAllRestaurants";
    
                DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);

                foreach (DataRow record in ds.Tables[0].Rows)
                {
                    Restaurant restaurant = new Restaurant();

                    restaurant.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
                    restaurant.OwnerID = Convert.ToInt32(record["OwnerID"]);
                    restaurant.Name = record["Name"].ToString();
                    restaurant.Cuisine = record["Cuisine"].ToString();
                    restaurant.StreetAddress = record["StreetAddress"].ToString();
                    restaurant.City = record["City"].ToString();
                    restaurant.State = record["State"].ToString();
                    restaurant.ZipCode = Convert.ToInt32(record["ZipCode"]);
                    restaurant.HoursOfOperation = record["HoursOfOperation"].ToString();
                    restaurant.Email = record["Email"].ToString();
                    restaurant.PhoneNum = record["PhoneNumber"].ToString();
                    restaurant.Description = record["Description"].ToString();
                    restaurant.OverallRating = Convert.ToDouble(record["OverallRating"]);
                    restaurant.AvgFoodRating = Convert.ToDouble(record["AvgFoodRating"]);
                    restaurant.AvgServiceRating = Convert.ToDouble(record["AvgServiceRating"]);
                    restaurant.AvgAtmosphereRating = Convert.ToDouble(record["AvgAtmosphereRating"]);
                    restaurant.AvgPriceRating = Convert.ToDouble(record["AvgPriceRating"]);
                    restaurant.WebsiteURL = record["WebsiteURL"].ToString();

                    restaurantList.Add(restaurant);
                }
            }
            ViewBag.Cuisines = GetAllCuisines();
            Debug.WriteLine($"Returning {restaurantList.Count} restaurants to view");
            return View("SearchRestaurants", restaurantList);
        }

        private List<string> GetAllCuisines()
        {
            List<string> cuisines = new List<string>();

            DBConnect dbConnect = new DBConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllCuisines";

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                cuisines.Add(record["Cuisine"].ToString());
            }
            return cuisines;
        }
    }
}
