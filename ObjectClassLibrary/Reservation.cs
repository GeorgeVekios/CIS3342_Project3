using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClassLibrary
{
    public class Reservation
    {
        private int reservationId;
        private int restId;
        private string name;
        private string phoneNumber;
        private string email;
        private DateTime resDT;
        private int partySize;
        private string comments;
        private string status;

        //default constructor
        public Reservation()
        {
            reservationId = 0;
            restId = 0;
            name = string.Empty;
            phoneNumber = string.Empty;
            resDT = DateTime.Now;
            partySize = 0;
            comments = string.Empty;
            status = string.Empty;
        }

        //parameterized
        public Reservation(int ResId, int Restid, string name, string PhoneNum, string Email, DateTime resDT, int partySize, string comments, string status)
        {
            this.reservationId = ResId;
            this.restId = Restid;
            this.name = name;
            this.phoneNumber = PhoneNum;
            this.email = Email;
            this.resDT = resDT;
            this.partySize = partySize;
            this.comments = comments;
            this.status = status;
        }

        public int ReservationId { get { return reservationId; } set { reservationId = value; } }
        public int RestId { get { return restId; } set { restId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime ResDT { get { return resDT; } set { resDT = value; } }
        public int PartySize { get { return partySize; } set { partySize = value; } }
        public string Comments { get { return comments; } set { comments = value; } }
        public string Status { get { return status; } set { status = value; } }
    }
}
