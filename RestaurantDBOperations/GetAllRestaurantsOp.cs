using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Utilities;

namespace RestaurantDBOperations
{
    public class GetAllRestaurantsOp
    {
        public List<Restaurant> GetAllRestaurants()
        {
            DBConnect dBConnect = new DBConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllRestaurants";

            DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);
            List<Restaurant> restaurantList = new List<Restaurant>();

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
            return restaurantList;
        } 
    }
}
