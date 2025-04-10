using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserDBOperations
{
    public class DoesEmailExistOp
    {
        public bool DoesEmailExist(string email) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_DoesEmailExist";

            cmd.Parameters.AddWithValue("@Email", email);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
    }
}
