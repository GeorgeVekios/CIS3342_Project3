using ObjectClassLibrary;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
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

            try
            {
                if (review.UserID >= 0)
                {
                    cmd.Parameters.AddWithValue("@UserID", review.UserID);
                }
                else
                {
                    throw new ArgumentException("UserID is required.");
                }

                if (review.RestaurantID > 0)
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", review.RestaurantID);
                }
                else
                {
                    throw new ArgumentException("RestaurantID is required.");
                }

                if (!string.IsNullOrEmpty(review.ReviewTitle))
                {
                    cmd.Parameters.AddWithValue("@ReviewTitle", review.ReviewTitle);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ReviewTitle", "");
                }

                if (!string.IsNullOrEmpty(review.ReviewBody))
                {
                    cmd.Parameters.AddWithValue("@ReviewBody", review.ReviewBody);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ReviewBody", "");
                }

                cmd.Parameters.AddWithValue("@FoodRating", review.FoodRating);
                cmd.Parameters.AddWithValue("@ServiceRating", review.ServiceRating);
                cmd.Parameters.AddWithValue("@AtmosphereRating", review.AtmosphereRating);
                cmd.Parameters.AddWithValue("@PriceRating", review.PriceRating);

                if (review.VisitDate < new DateTime(1753, 1, 1))
                {
                    cmd.Parameters.AddWithValue("@VisitDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VisitDate", review.VisitDate);
                }

                if (review.CreatedAt < new DateTime(1753, 1, 1))
                {
                    cmd.Parameters.AddWithValue("@CreatedAt", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CreatedAt", review.CreatedAt);
                }

                int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);

                return rowsAffected;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL ERROR: " + ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    Console.WriteLine($"SQL ERROR #{err.Number}: {err.Message} (Line {err.LineNumber})");
                }
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General ERROR: " + ex.Message);
                return -1;
            }
        }
    }
}
