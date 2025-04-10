using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClassLibrary;
using Utilities;

namespace ReservationDBOperations
{
    public class AddReservationOp
    {
        public int AddReservation(Reservation res)
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_AddReservation"; // Hypothetical stored procedure

            // Map Reservation properties to stored procedure parameters
            cmd.Parameters.AddWithValue("@RestaurantID", res.RestId);
            cmd.Parameters.AddWithValue("@Name", res.Name);
            cmd.Parameters.AddWithValue("@PhoneNumber", res.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", res.Email);
            cmd.Parameters.AddWithValue("@DateTime", res.ResDT);
            cmd.Parameters.AddWithValue("@PartySize", res.PartySize);
            cmd.Parameters.AddWithValue("@Comments", res.Comments ?? (object)DBNull.Value); // Handle null comments

            // Execute the stored procedure
            int rowsAffected = dBConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
