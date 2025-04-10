using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class ManageReviewsViewModel
    {
        private List<Review> reviewList;

        public List<Review> ReviewList 
        { 
            get { return reviewList; } 
            set { reviewList = value; }
        }

        public ManageReviewsViewModel()
        {

        }

        public ManageReviewsViewModel (List<Review> reviewList)
        {
            ReviewList = reviewList;
        }
    }
}
