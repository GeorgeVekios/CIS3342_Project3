using ObjectClassLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DBOperationsClassLibrary
{
    public class GetSecurityRecordByIDOp
    {
        public SecurutyQuestionForUser GetSecurityRecordByID(int securityRecordID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetSecurityRecordByID";

            cmd.Parameters.AddWithValue("@SecurityRecordID", securityRecordID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            DataRow record = ds.Tables[0].Rows[0];

            SecurutyQuestionForUser securutyQuestionForUser = new SecurutyQuestionForUser();

            securutyQuestionForUser.SecurityRecordID = Convert.ToInt32(record["SecurityRecordID"]);
            securutyQuestionForUser.UserID = Convert.ToInt32(record["UserID"]);
            securutyQuestionForUser.SecurityQuestionID = Convert.ToInt32(record["SecurityQuestionID"]);
            securutyQuestionForUser.HashedAnswer = Convert.ToString(record["Answer"]);

            return securutyQuestionForUser;
        }
    }
}
