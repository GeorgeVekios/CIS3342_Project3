using System.Data.SqlClient;
using Utilities;

namespace ReviewDBOperations
{
    public class DeleteReviewOp
    {
        public int DeleteReview(int reviewID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "TP_DeleteReview";
            cmd.Parameters.AddWithValue("@ReviewID", reviewID);

            int rowsAffected = dbConnect.DoUpdateUsingCmdObj(cmd);

            return rowsAffected;
        }
    }
}
