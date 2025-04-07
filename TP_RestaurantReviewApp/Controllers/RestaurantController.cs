using Microsoft.AspNetCore.Mvc;
using TP_RestaurantReviewApp.Models;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TP_RestaurantReviewApp.Controllers
{
    public class RestaurantController : Controller
    {
        [HttpGet("Restaurant/ViewRestaurantProfile/{id}")]
        // route: Restaurants/ViewRestaurantProfile/id
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

        [HttpGet("Restaurant/CreateRestaurantPage/")]
        public IActionResult CreateRestaurantPage()
        {
            return View(new Restaurant());
        }

        [HttpPost]
        public IActionResult CreateRestaurantPage(Restaurant restaurant, int userID)
        {
            try
            {
                DBConnect dBConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_CreateRestaurantByUserID";

                //add parameters

                cmd.Parameters.AddWithValue("@OwnerID", userID);
                cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                cmd.Parameters.AddWithValue("@Cuisine", restaurant.Cuisine);
                cmd.Parameters.AddWithValue("@StreetAddress", restaurant.StreetAddress);
                cmd.Parameters.AddWithValue("@City", restaurant.City);
                cmd.Parameters.AddWithValue("@State", restaurant.State);
                cmd.Parameters.AddWithValue("@ZipCode", restaurant.ZipCode);
                cmd.Parameters.AddWithValue("@HoursOfOperation", restaurant.HoursOfOperation);
                cmd.Parameters.AddWithValue("@Email", restaurant.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", restaurant.PhoneNum);
                cmd.Parameters.AddWithValue("@Description", restaurant.Description);
                cmd.Parameters.AddWithValue("@WebsiteURL", restaurant.WebsiteURL);


                dBConnect.DoUpdateUsingCmdObj(cmd);

                ViewBag.Message = "Restaurant added successfully!";

                // Reset form
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
