using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Utilities;

namespace RestaurantDBOperations
{
    public class SearchRestaurantsOp
    {
        public List<Restaurant> SearchRestaurants(string city, string state, List<string> cuisines)
        {
            string cleanCity;
            string cleanState;

            if (string.IsNullOrWhiteSpace(city))
            {
                cleanCity = null;
            }
            else
            {
                cleanCity = city.Trim();
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                cleanState = null;
            }
            else
            {
                cleanState = state.Trim();
            }

            bool isSearch = !string.IsNullOrEmpty(cleanCity) || !string.IsNullOrEmpty(cleanState) || (cuisines != null && cuisines.Any());
            List<Restaurant> restaurantList = new List<Restaurant>();

            if (isSearch)
            {
                string cuisineList = null;

                if (cuisines != null && cuisines.Count > 0)
                {
                    cuisineList = string.Join(",", cuisines);
                }
                else
                {
                    cuisineList = null;
                }

                DBConnect dBConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TP_SearchRestaurants";

                if (cleanCity == null)
                {
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@City", cleanCity);
                }

                if (cleanState == null)
                {
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@State", cleanState);
                }

                if (cuisineList == null)
                {
                    cmd.Parameters.AddWithValue("@CuisineList", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CuisineList", cuisineList);
                }

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
            else
            {
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
            return restaurantList;
        }
    }
}
