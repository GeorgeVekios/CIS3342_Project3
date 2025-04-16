using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ReviewDBOperations
{
    public class GetReviewByIDOp
    {
        public Review GetReviewByID(int reviewID) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReviewByID";

            cmd.Parameters.AddWithValue("@ReviewID", reviewID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            DataRow record = ds.Tables[0].Rows[0];
            Review review = new Review();

            review.ReviewID = Convert.ToInt32(record["ReviewID"]);
            review.UserID = Convert.ToInt32(record["UserID"]);
            review.RestaurantID = Convert.ToInt32(record["RestaurantID"]);
            review.ReviewTitle = Convert.ToString(record["ReviewTitle"]);
            review.ReviewBody = Convert.ToString(record["ReviewBody"]);
            review.FoodRating = Convert.ToInt32(record["FoodRating"]);
            review.ServiceRating = Convert.ToInt32(record["ServiceRating"]);
            review.AtmosphereRating = Convert.ToInt32(record["AtmosphereRating"]);
            review.PriceRating = Convert.ToInt32(record["PriceRating"]);
            review.VisitDate = Convert.ToDateTime(record["VisitDate"]);
            review.CreatedAt = Convert.ToDateTime(record["CreatedAt"]);

            return review;
        }
    }
}
