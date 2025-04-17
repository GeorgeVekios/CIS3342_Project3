using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class UpdateUserPasswordOp
    {
        public int UpdateUserPassword(int userID, string newPassword)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_UpdateUserPassword";

            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@NewPassword", newPassword);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
