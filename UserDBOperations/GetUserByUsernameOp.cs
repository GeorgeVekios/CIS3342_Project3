using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class GetUserByUsernameOp
    {
        public User GetUserByUsername(string username)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetUserByUsername";

            cmd.Parameters.AddWithValue("@Username", username);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            DataRow record = ds.Tables[0].Rows[0];

            User user = new User();

            user.UserID = Convert.ToInt32(record["UserID"]);
            user.UserType = Convert.ToString(record["UserType"]);
            user.FirstName = Convert.ToString(record["FirstName"]);
            user.LastName = Convert.ToString(record["LastName"]);
            user.Username = Convert.ToString(record["Username"]);
            user.Password = Convert.ToString(record["Password"]);
            user.Email = Convert.ToString(record["Email"]);
            user.PhoneNum = Convert.ToString(record["PhoneNum"]);
            user.CreatedAt = Convert.ToDateTime(record["CreatedAt"]);
            user.IsVerified = Convert.ToBoolean(record["IsVerified"]);
            user.SecurityRecord1 = Convert.ToInt32(record["SecurityRecord1"]);
            user.SecurityRecord2 = Convert.ToInt32(record["SecurityRecord2"]);
            user.SecurityRecord3 = Convert.ToInt32(record["SecurityRecord3"]);

            return user;
        }
    }
}
