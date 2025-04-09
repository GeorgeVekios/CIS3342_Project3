using ObjectClassLibrary;

namespace TP_RestaurantReviewApp.Models
{
    public class SearchRestaurantsViewModel
    {
        private List<Restaurant> restaurantList;

        public List<Restaurant> RestaurantList
        {
            get { return restaurantList; }
            set { restaurantList = value; }
        }

        public SearchRestaurantsViewModel()
        {

        }

        public SearchRestaurantsViewModel(List<Restaurant> restaurantList)
        {
            RestaurantList = restaurantList;
        }
    }
}
