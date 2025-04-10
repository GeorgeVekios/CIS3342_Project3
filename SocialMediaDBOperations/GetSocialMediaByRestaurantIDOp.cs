using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SocialMediaDBOperations
{
    public class GetSocialMediaByRestaurantIDOp
    {
        public List<SocialMedia> GetSocialMediaByRestaurantID(int restaurantID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetSocialMediaByRestaurantID";

            cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);

            List<SocialMedia> socialMediaList = new List<SocialMedia>();

            foreach(DataRow record in ds.Tables[0].Rows)
            {
                SocialMedia socialMedia = new SocialMedia();

                socialMedia.SocialMediaID = Convert.ToInt32(record["SocialMediaID"]);
                socialMedia.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
                socialMedia.Platform = Convert.ToString(record["Platform"]);
                socialMedia.Link = Convert.ToString(record["Link"]);

                socialMediaList.Add(socialMedia);
            }
            return socialMediaList;
        }
    }
}
