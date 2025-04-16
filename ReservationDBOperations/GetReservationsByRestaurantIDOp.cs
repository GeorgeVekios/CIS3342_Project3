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
    internal class GetReservationsByRestaurantIDOp
    {
        public List<Reservation> GetReservationsByRestaurantID(int restaurantID)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TP_GetReservationsByRestaurantID";

            cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

            DataSet ds = dbConnect.GetDataSetUsingCmdObj(cmd);
            List<Reservation> resList = new List<Reservation>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
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

                resList.Add(reservation);
            }
            return resList;
        }
    }
}
