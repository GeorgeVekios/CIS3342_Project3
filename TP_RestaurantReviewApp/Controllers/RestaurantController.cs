using Microsoft.AspNetCore.Mvc;
using TP_RestaurantReviewApp.Models;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TP_RestaurantReviewApp.Controllers
{
    public class RestaurantController : Controller
    {
        // [HttpGet("Restaurants/ViewRestaurantProfile/{id}")]
        // route: Restaurants/ViewRestaurantProfile/id
        public IActionResult ViewRestaurantProfile(int id)
        {
            Restaurant restaurant = new Restaurant();
            DBConnect dBConnect = new DBConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            command.CommandText = "TP_GetRestaurantByID";

            command.Parameters.AddWithValue("@RestaurantID", id);

            DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow record = ds.Tables[0].Rows[0];

                restaurant.restaurantID = Convert.ToInt32(record["RestaurantID"]);
                restaurant.ownerID = Convert.ToInt32(record["OwnerID"]);
                restaurant.name = record["Name"].ToString();
                restaurant.cuisine = record["Cuisine"].ToString();
                restaurant.streetAddress = record["StreetAddress"].ToString();
                restaurant.city = record["City"].ToString();
                restaurant.state = record["State"].ToString();
                restaurant.zipCode = Convert.ToInt32(record["ZipCode"]);
                restaurant.hoursOfOperation = record["HoursOfOperation"].ToString();
                restaurant.email = record["Email"].ToString();
                restaurant.phoneNum = record["PhoneNumber"].ToString();
                restaurant.description = record["Description"].ToString();
                restaurant.overallRating = Convert.ToDouble(record["OverallRating"]);
                restaurant.avgFoodRating = Convert.ToDouble(record["AvgFoodRating"]);
                restaurant.avgServiceRating = Convert.ToDouble(record["AvgServiceRating"]);
                restaurant.avgAtmosphereRating = Convert.ToDouble(record["AvgAtmosphereRating"]);
                restaurant.avgPriceRating = Convert.ToDouble(record["AvgPriceRating"]);
                restaurant.websiteURL = record["WebsiteURL"].ToString();
            }
            return View(restaurant);
        }
    }
}
