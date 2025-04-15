using ObjectClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ReservationDBOperations
{
    public class GetReservationByReservationIDOp
    {
        public Reservation GetReservationByReservationID(int resID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReservationByReservationID";

            cmd.Parameters.AddWithValue("@ReservationID", resID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            List<Reservation> resList = new List<Reservation>();
            
            //should only return 1 row
            DataRow row = ds.Tables[0].Rows[0];

            Reservation reservation = new Reservation();

            reservation.ReservationId = Convert.ToInt32(row["reservationID"]);
            reservation.RestId = Convert.ToInt32(row["RestaurantID"]);
            reservation.Name = Convert.ToString(row["Name"]);
            reservation.PhoneNumber = Convert.ToString(row["PhoneNumber"]);
            reservation.Email = Convert.ToString(row["FoodRating"]);
            reservation.ResDT = Convert.ToDateTime(row["ResDateTime"]);
            reservation.PartySize = Convert.ToInt32(row["PartySize"]);
            reservation.Comments = Convert.ToString(row["Comments"]);
            reservation.Status = Convert.ToString(row["Status"]);
            return reservation;
        }
    }
}
