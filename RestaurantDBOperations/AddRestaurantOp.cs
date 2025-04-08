using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RestaurantDBOperations
{
    public class AddRestaurantOp
    {
        public int AddRestaurant(Restaurant restaurant)
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_AddRestaurant"; 

            cmd.Parameters.AddWithValue("@OwnerID", restaurant.OwnerID);
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

            int rowsAffected = dBConnect.DoUpdateUsingCmdObj(cmd);

            return rowsAffected;
        }
    }
}
