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
    public class DeleteRestaurantByRestaurantIDOp
    {
        private DBConnect dbConnect = new DBConnect();
        public int DeleteRestaurantByRestaurantID(int restID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_DeleteRestaurantByID";

            cmd.Parameters.AddWithValue("@RestaurantID", restID);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
