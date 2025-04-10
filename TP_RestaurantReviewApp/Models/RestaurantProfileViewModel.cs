using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class RestaurantProfileViewModel
    {
        private Restaurant restaurant;
        private List<Review> reviewList;
        private List<Image> imageGallery;
        private List<SocialMedia> socialMediaList;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        public List<Review> ReviewList
        {
            get { return reviewList; }
            set { reviewList = value; }
        }

        public List<Image> ImageGallery
        {
            get { return imageGallery; }
            set { imageGallery = value; }
        }

        public List<SocialMedia> SocialMediaList
        {
            get { return socialMediaList; }
            set { socialMediaList = value; }
        }

        public RestaurantProfileViewModel()
        {

        }

        public RestaurantProfileViewModel(Restaurant restaurant, List<Review> reviewList, List<Image> imageGallery, List<SocialMedia> socialMediaList)
        {
            Restaurant = restaurant;
            ReviewList = reviewList;
            ImageGallery = imageGallery;
            SocialMediaList = socialMediaList;
        }
    }
}
