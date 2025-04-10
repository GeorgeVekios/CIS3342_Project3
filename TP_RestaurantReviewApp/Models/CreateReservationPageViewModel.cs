using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class CreateReservationPageViewModel
    {
        public Reservation Reservation { get; set; }
        public string Message { get; set; }
        public int RestaurantID { get; set; }
    }
}
