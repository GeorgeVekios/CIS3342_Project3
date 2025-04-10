using ObjectClassLibrary;
using System.Data.SqlClient;
using Utilities;

namespace UserDBOperations
{
    public class RegisterUserOp
    {
        public int RegisterUser(User user) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_RegisterUser";

            cmd.Parameters.AddWithValue("@UserType", user.UserType);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNum", user.PhoneNum);
            cmd.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
            cmd.Parameters.AddWithValue("@IsVerified", user.IsVerified);
            cmd.Parameters.AddWithValue("@SecurityRecord1", user.SecurityRecord1);
            cmd.Parameters.AddWithValue("@SecurityRecord2", user.SecurityRecord2);
            cmd.Parameters.AddWithValue("@SecurityRecord3", user.SecurityRecord3);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);

            return rowsAffected;
        }
    }
}
