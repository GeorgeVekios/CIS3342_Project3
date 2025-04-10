using ObjectClassLibrary;
using System.Data.SqlClient;
using Utilities;

namespace ReviewDBOperations
{
    public class AddReviewOp
    {
        public int AddReview(Review review) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_AddReview";

            cmd.Parameters.AddWithValue("@UserID", review.UserID);
            cmd.Parameters.AddWithValue("@RestaurantID", review.RestaurantID);
            cmd.Parameters.AddWithValue("@ReviewTitle", review.ReviewTitle);
            cmd.Parameters.AddWithValue("@ReviewBody", review.ReviewBody);
            cmd.Parameters.AddWithValue("@FoodRating", review.FoodRating);
            cmd.Parameters.AddWithValue("@ServiceRating", review.ServiceRating);
            cmd.Parameters.AddWithValue("@AtmosphereRating", review.AtmosphereRating);
            cmd.Parameters.AddWithValue("@PriceRating", review.PriceRating);
            cmd.Parameters.AddWithValue("@VisitDate", review.VisitDate);
            cmd.Parameters.AddWithValue("@CreatedAt", review.CreatedAt);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);

            return rowsAffected;
        }
    }
}
