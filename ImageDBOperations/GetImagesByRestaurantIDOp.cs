using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ImageDBOperations
{
    public class GetImagesByRestaurantIDOp
    {
        public List<Image> GetImagesByRestaurantID(int restaurantID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetImagesByRestaurantID";

            cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            List<Image> imageList = new List<Image>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Image image = new Image();

                image.ImageId = Convert.ToInt32(record["ImageID"]);
                image.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
                image.FileLocation = Convert.ToString(record["FileLocation"]);
                image.Caption = Convert.ToString(record["Caption"]);
                image.StorageSize = Convert.ToString(record["StorageSize"]);

                imageList.Add(image);
            }
            return imageList;
        }
    }
}
