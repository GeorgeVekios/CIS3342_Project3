using ObjectClassLibrary;
using System.Data.SqlClient;
using Utilities;

namespace ReviewDBOperations
{
    public class UpdateReviewOp
    {
        public int UpdateReview(Review review) 
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_UpdateReview";

            cmd.Parameters.AddWithValue("@ReviewID", review.ReviewID);
            cmd.Parameters.AddWithValue("@ReviewTitle", review.ReviewTitle);
            cmd.Parameters.AddWithValue("@ReviewBody", review.ReviewBody);
            cmd.Parameters.AddWithValue("@FoodRating", review.FoodRating);
            cmd.Parameters.AddWithValue("@ServiceRating", review.ServiceRating);
            cmd.Parameters.AddWithValue("@AtmosphereRating", review.AtmosphereRating);
            cmd.Parameters.AddWithValue("@PriceRating", review.PriceRating);
            cmd.Parameters.AddWithValue("@VisitDate", review.VisitDate);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
