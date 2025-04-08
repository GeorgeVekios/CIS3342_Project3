namespace ObjectClassLibrary
{
    public class Restaurant
    {
        private int restaurantID;
        private int ownerID;
        private string name;
        private string cuisine;
        private string streetAddress;
        private string city;
        private string state;
        private int zipCode;
        private string hoursOfOperation;
        private string email;
        private string phoneNum;
        private string description;
        private double overallRating;
        private double avgFoodRating;
        private double avgAtmosphereRating;
        private double avgServiceRating;
        private double avgPriceRating;
        private string websiteURL;

        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }

        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Cuisine
        {
            get { return cuisine; }
            set { cuisine = value; }
        }

        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string HoursOfOperation
        {
            get { return hoursOfOperation; }
            set { hoursOfOperation = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double OverallRating
        {
            get { return overallRating; }
            set { overallRating = value; }
        }

        public double AvgFoodRating
        {
            get { return avgFoodRating; }
            set { avgFoodRating = value; }
        }

        public double AvgAtmosphereRating
        {
            get { return avgAtmosphereRating; }
            set { avgAtmosphereRating = value; }
        }

        public double AvgServiceRating
        {
            get { return avgServiceRating; }
            set { avgServiceRating = value; }
        }

        public double AvgPriceRating
        {
            get { return avgPriceRating; }
            set { avgPriceRating = value; }
        }

        public string WebsiteURL
        {
            get { return websiteURL; }
            set { websiteURL = value; }
        }

        public Restaurant()
        {

        }
        public Restaurant(int ownerID, string name, string cuisine, string streetAddress, string city, string state, int zipCode,
                          string hoursOfOperation, string email, string phoneNum, string description, double overallRating,
                          double avgFoodRating, double avgAtmosphereRating, double avgServiceRating, double avgPriceRating, string websiteURL)
        {
            this.ownerID = ownerID;
            this.name = name;
            this.cuisine = cuisine;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.hoursOfOperation = hoursOfOperation;
            this.email = email;
            this.phoneNum = phoneNum;
            this.description = description;
            this.overallRating = overallRating;
            this.avgFoodRating = avgFoodRating;
            this.avgAtmosphereRating = avgAtmosphereRating;
            this.avgServiceRating = avgServiceRating;
            this.avgPriceRating = avgPriceRating;
            this.websiteURL = websiteURL;
        }

        public Restaurant(int restaurantID, int ownerID, string name, string cuisine, string streetAddress, string city, string state, int zipCode,
                          string hoursOfOperation, string email, string phoneNum, string description, double overallRating,
                          double avgFoodRating, double avgAtmosphereRating, double avgServiceRating, double avgPriceRating, string websiteURL)
        {
            this.restaurantID = restaurantID;
            this.ownerID = ownerID;
            this.name = name;
            this.cuisine = cuisine;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.hoursOfOperation = hoursOfOperation;
            this.email = email;
            this.phoneNum = phoneNum;
            this.description = description;
            this.overallRating = overallRating;
            this.avgFoodRating = avgFoodRating;
            this.avgAtmosphereRating = avgAtmosphereRating;
            this.avgServiceRating = avgServiceRating;
            this.avgPriceRating = avgPriceRating;
            this.websiteURL = websiteURL;
        }
    }
}
