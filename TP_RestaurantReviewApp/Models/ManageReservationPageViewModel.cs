using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class ManageReservationPageViewModel
    {
        public int RestaurantID {  get; set; }
        public Reservation Reservation { get; set; }
        public string Message { get; set; }
    }
}
