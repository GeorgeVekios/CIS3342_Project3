using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class CreateReviewViewModel
    {
        private Review review;

        public Review Review
        {
            get { return review; }
            set { review = value; }
        }

        public CreateReviewViewModel ()
        {

        }

        public CreateReviewViewModel(Review review)
        {
            this.review = review;
        }
    }
}
