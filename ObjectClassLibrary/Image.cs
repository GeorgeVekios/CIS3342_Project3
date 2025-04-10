using System;

namespace ObjectClassLibrary
{
    public class Image
    {
        private string fileLocation;
        private string caption;
        private string storagesize;
        private int imageId;
        private int restaurantID;


        //default constructor
        public Image()
        {
            fileLocation = string.Empty;
            caption = string.Empty;
            storagesize = string.Empty;
            imageId = -1;
            restaurantID = -1;

        }

        //parameterized
        public Image(string FileLocation, string Caption, string StorageSize, int ImageId, int RestaurantID)
        {
            this.fileLocation = FileLocation;
            this.caption = Caption;
            this.storagesize = StorageSize;
            this.imageId = ImageId;
            this.restaurantID = RestaurantID;
        }

        //getters, setters
        public string FileLocation { get { return fileLocation; } set { this.fileLocation = value; } }
        public string Caption { get { return caption; } set { this.caption = value; } }
        public string StorageSize { get { return StorageSize; } set { this.StorageSize = value; } }
        public int ImageId { get { return imageId; } set { this.imageId = value; } }
        public int RestaurantID { get { return restaurantID; } set { restaurantID = value; } }
    }
}
