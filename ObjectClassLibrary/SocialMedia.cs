using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClassLibrary
{
    public class SocialMedia
    {
        private int socialMediaID;
        private int restaurantID;
        private string platform;
        private string link;

        public int SocialMediaID
        {
            get { return socialMediaID; }
            set { socialMediaID = value; }
        }

        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }

        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public SocialMedia()
        {

        }

        public SocialMedia(int restaurantID, string platform, string link)
        {
            RestaurantID = restaurantID;
            Platform = platform;
            Link = link;
        }

        public SocialMedia(int socialMediaID, int restaurantID, string platform, string link)
        {
            SocialMediaID = socialMediaID;
            RestaurantID = restaurantID;
            Platform = platform;
            Link = link;
        }
    }
}
