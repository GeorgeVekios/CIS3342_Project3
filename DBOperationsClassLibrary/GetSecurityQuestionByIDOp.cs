using ObjectClassLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DBOperationsClassLibrary
{
    public class GetSecurityQuestionByIDOp
    {
        public SecurityQuestion GetSecurityQuestionByID(int securityQuestionID) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetSecurityQuestionByID";

            cmd.Parameters.AddWithValue("@securityQuestionID", securityQuestionID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            DataRow record = ds.Tables[0].Rows[0];

            SecurityQuestion question = new SecurityQuestion();
            question.SecurityQuestionID = Convert.ToInt32(record["SecurityQuestionID"]);
            question.QuestionText = Convert.ToString(record["QuestionText"]);

            return question;
        }
    }
}
