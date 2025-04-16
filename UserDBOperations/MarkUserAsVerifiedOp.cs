using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class MarkUserAsVerifiedOp
    {
        public int MarkUserAsVerified(int userId)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_MarkUserAsVerified";
            
            cmd.Parameters.AddWithValue("@UserID", userId);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
