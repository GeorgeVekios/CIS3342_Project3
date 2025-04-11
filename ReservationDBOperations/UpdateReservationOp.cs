using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClassLibrary


using Utilities;

namespace ReservationDBOperations
{
    public class UpdateReservationOp
    {
        public int UpdateReservation(Reservation res)
        {
            DBConnect dBConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_UpdateReservation";

            //map properties to stored procedure params
            cmd.Parameters.AddWithValue("@RestaurantID", res.RestId);
            cmd.Parameters.AddWithValue("@ReservationID", res.ReservationId);
            cmd.Parameters.AddWithValue("@Name", res.Name);
            cmd.Parameters.AddWithValue("@PhoneNumber", res.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", res.Email);
            cmd.Parameters.AddWithValue("@DateTime", res.ResDT);
            cmd.Parameters.AddWithValue("@PartySize", res.PartySize);
            cmd.Parameters.AddWithValue("@Comments", res.Comments ?? (object)DBNull.Value); //null comments


            int rowsAffected = dBConnect.DoUpdateUsingCmdObj(cmd);
            return rowsAffected;
        }
    }
}
