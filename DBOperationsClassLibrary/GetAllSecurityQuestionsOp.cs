using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DBOperationsClassLibrary
{
    public class GetAllSecurityQuestionsOp {

        public List<SecurityQuestion> GetAllSecurityQuestions()
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllSecurityQuestions";

            DataSet ds = dBConnect.GetDataSetUsingCmdObj(cmd);

            List<SecurityQuestion> securityQuestions = new List<SecurityQuestion>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                SecurityQuestion question = new SecurityQuestion();
                question.SecurityQuestionID = Convert.ToInt32(record["SecurityQuestionID"]);
                question.QuestionText = Convert.ToString(record["QuestionText"]);

                securityQuestions.Add(question);
            }
            return securityQuestions;
        }
    }
}
