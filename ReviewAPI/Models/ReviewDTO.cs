namespace ReviewAPI.Models
{
    public class ReviewDTO
    {
        private int reviewID;
        private int userID;
        private int restaurantID;
        private string reviewTitle;
        private string reviewBody;
        private int foodRating;
        private int serviceRating;
        private int atmosphereRating;
        private int priceRating;
        private DateTime visitDate;
        private DateTime createdAt;

        public int ReviewID
        {
            get { return reviewID; }
            set { reviewID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }

        public string ReviewTitle
        {
            get { return reviewTitle; }
            set { reviewTitle = value; }
        }

        public string ReviewBody
        {
            get { return reviewBody; }
            set { reviewBody = value; }
        }

        public int FoodRating
        {
            get { return foodRating; }
            set { foodRating = value; }
        }

        public int ServiceRating
        {
            get { return serviceRating; }
            set { serviceRating = value; }
        }

        public int AtmosphereRating
        {
            get { return atmosphereRating; }
            set { atmosphereRating = value; }
        }

        public int PriceRating
        {
            get { return priceRating; }
            set { priceRating = value; }
        }

        public DateTime VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public ReviewDTO()
        {

        }

        public ReviewDTO(int userID, int restaurantID, string reviewTitle,
                     string reviewBody, int foodRating, int serviceRating,
                     int atmosphereRating, int priceRating, DateTime visitDate,
                     DateTime createdAt)
        {
            this.userID = userID;
            this.restaurantID = restaurantID;
            this.reviewTitle = reviewTitle;
            this.reviewBody = reviewBody;
            this.foodRating = foodRating;
            this.serviceRating = serviceRating;
            this.atmosphereRating = atmosphereRating;
            this.priceRating = priceRating;
            this.visitDate = visitDate;
            this.createdAt = createdAt;
        }
        public ReviewDTO(int reviewID, int userID, int restaurantID, string reviewTitle,
                     string reviewBody, int foodRating, int serviceRating,
                     int atmosphereRating, int priceRating, DateTime visitDate,
                     DateTime createdAt)
        {
            this.reviewID = reviewID;
            this.userID = userID;
            this.restaurantID = restaurantID;
            this.reviewTitle = reviewTitle;
            this.reviewBody = reviewBody;
            this.foodRating = foodRating;
            this.serviceRating = serviceRating;
            this.atmosphereRating = atmosphereRating;
            this.priceRating = priceRating;
            this.visitDate = visitDate;
            this.createdAt = createdAt;
        }
    }
}
