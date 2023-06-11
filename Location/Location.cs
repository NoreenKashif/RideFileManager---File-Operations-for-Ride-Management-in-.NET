namespace LocationLibrary
{
    public class Location
    {
        
        private float longitude;
        private float latitude;
        public Location()
        {
            latitude = 0;
            longitude = 0;
        }
        public float Latitude
        {
            get
            {
                return latitude;    
            }
            set
            {
                latitude = value;   
            }
        }
        public float Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }
        public void setLocation(float longitude1, float latitude1)
        {
            this.longitude = longitude1;
            this.latitude = latitude1;  
        }
    }
}