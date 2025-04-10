using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace ReviewDBOperations
{
    public class GetReviewsByUserIDOp
    {
        public List<Review> GetReviewsByUserID(int userID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReviewsByUserID";

            cmd.Parameters.AddWithValue("@UserID", userID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);

            List<Review> reviewList = new List<Review>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
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

                reviewList.Add(review);
            }
            return reviewList;
        }
    }
}
