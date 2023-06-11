using LocationLibrary;
using DriverLibrary;
using PassengerLibrary;
namespace RideLibrary
{
    public class Ride
    {
        private Location start_location;
        private Location end_location;
        public double price;
        public Driver driver;
        public Passenger passenger;
        public Ride()
        {
            start_location = new Location();
            end_location = new Location();
            price = 0.0;
            driver = new Driver();
            passenger = new Passenger();
        }
        public Passenger assignPassenger()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Your Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Your PhoneNo: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string phone_no = Console.ReadLine();
            passenger = new Passenger(name, phone_no);
            return passenger;
            
        }
        private double getDistance()//helper function to find distance
        {
            double start1Y = start_location.Latitude;
            double start1X = start_location.Longitude;

            double start2Y = end_location.Latitude;
            double start2X = end_location.Longitude;

            //Distance of Passenger between END & START
            double distance = Math.Sqrt(Math.Pow(start2X - start1X, 2) + Math.Pow(start2Y - start1Y, 2));
            return distance;
        }
        public Driver assignDriver(List<Driver> drivers, string rideType)
        {
          
             rideType = rideType.ToLower();
            //PASSENGER's Starting and Ending LOcation for dISTANCE MEASURING
            double distance = getDistance();//6

            double startY = start_location.Latitude;
            double startX = start_location.Longitude;

            // Define the driver's location 
            

            // Calculate the Euclidean distance between the two locations
            //double distance1 = Math.Sqrt(Math.Pow(driverX - startX, 2) + Math.Pow(driverY - startY, 2));

            int closestDriverID = 0;
            double minDistance = distance;//6

            foreach (Driver driver in drivers)
            {
                double driverY = driver.curr_location.Latitude;
                double driverX = driver.curr_location.Longitude;
                double distance1 = Math.Sqrt(Math.Pow(driverX - startX, 2) + Math.Pow(driverY - startY, 2));
                if (driver.availability==true && distance1 <= minDistance && driver.vehicle.Type==rideType)
                {
                    minDistance = distance;
                    closestDriverID = driver.driver_id;
                    return driver;
                }
            }

            return driver;
        }
        public void giveRating(Driver driver1)
        {
            Console.WriteLine("Give a Rating   <<<<From 1 to 5>>>>: ");
            string rate = Console.ReadLine();
            int rating1 = int.Parse(rate);
            if (rating1 >= 1 && rating1 <= 5)
            {
                driver1.rating.Add(rating1);

            }
        }
        public void setLocation(Location start_loc, Location end_loc)
        {
            start_location.Longitude = start_loc.Longitude;
            start_location.Latitude = start_loc.Latitude;
            end_location.Longitude=end_loc.Longitude;
            end_location.Latitude=end_loc.Latitude; 
        }
        public double calculatePrice(string rideType)
        {
            double price = 0.0;
            rideType = rideType.ToLower();  
            double distance = getDistance();
            if(rideType == "bike")
            {
                price = ((distance * 300) / 50) + 0.05;
            }
            if(rideType == "car")
            {
                price = ((distance * 300) / 15) + 0.2;
            }
            if(rideType == "rickshaw")
            {
                price = ((distance * 300) / 35) + 0.1;
            }
            return price;
        }

    }
}