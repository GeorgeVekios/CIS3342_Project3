using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DBOperationsClassLibrary
{
    public class GetAllCuisinesOp
    {
        public List<string> GetAllCuisines() 
        {
            List<string> cuisines = new List<string>();

            DBConnect dbConnect = new DBConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetAllCuisines";

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                cuisines.Add(record["Cuisine"].ToString());
            }
            return cuisines;
        }
    }
}
