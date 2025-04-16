using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class SaveSecurityAnswerOp
    {
        public int SaveUserSecurityAnswer(int userID, int securityQuestionID, string answer)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_SaveUserSecurityAnswer";

            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@SecurityQuestionID", securityQuestionID);
            cmd.Parameters.AddWithValue("@Answer", answer);

            SqlParameter outputParam = new SqlParameter("@NewAnswerID", System.Data.SqlDbType.Int);
            outputParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            dbConnect.DoUpdateUsingCmdObj(cmd);
            return (int)cmd.Parameters["@NewAnswerID"].Value;
        }
    }
}
