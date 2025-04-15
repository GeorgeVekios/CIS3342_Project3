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
    public class GetRestaurantByUserIDOp
    {
        private DBConnect dbConnect = new DBConnect();
        public int GetRestaurantIDByUserID(int userID)
        {

            Restaurant restaurant = new Restaurant();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetRestaurantIDByUserID"; //TODO: Create stored procedure

            cmd.Parameters.AddWithValue("@RestaurantID", userID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            int restaurantID = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow record = ds.Tables[0].Rows[0];

                restaurantID = Convert.ToInt32(record["RestaurantID"]);
            }
            return restaurantID;
        }
    }
}
