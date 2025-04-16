using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class InsertSecurityAnswerIntoUserTableOp
    {
        public int InsertSecurityAnswerIntoUserTable(int userID, int securityRecordID, int questionNum)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@SecurityRecordID", securityRecordID);

            if (questionNum == 1)
            {
                cmd.CommandText = "TP_InsertSecurityRecord1IntoUserTable";
            }
            else if (questionNum == 2)
            {
                cmd.CommandText = "TP_InsertSecurityRecord2IntoUserTable";
            }
            else if (questionNum == 3)
            {
                cmd.CommandText = "TP_InsertSecurityRecord3IntoUserTable";
            }
            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
