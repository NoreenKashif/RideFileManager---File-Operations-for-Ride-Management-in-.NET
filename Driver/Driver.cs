using System;
using VehicleLibrary;
using LocationLibrary;
namespace DriverLibrary
{
    public class Driver : Object
    {
        private static int id  = 0;
        public int driver_id;
        public int Id
        {
            get
            {
                return driver_id;
            } 
            set
            {
                driver_id = value;
            }
        }
        public string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string phoneNo;
        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                phoneNo = value;
            }
        }
        public Vehicle vehicle;
        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle.Type = value.Type;
                vehicle.Model = value.Model;
                vehicle.Licence_Plate = value.Licence_Plate;
            }
        }
        public Location curr_location;
        public Location Curr_Location
        {
            get
            {
                return curr_location;
            }
            set
            {
                curr_location.Longitude = value.Longitude;
                curr_location.Latitude = value.Latitude;
            }
        }
        public List<int> rating;
        
        public bool availability;
        public bool Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }
        public override string ToString()
        {
            double rating_avg = getRating();
            string driver = $"ID: {driver_id}\nNAME: {name}\nAGE: {age}\nGENDER: {gender}\nADDRES: {address}\n CURR_LOCATION: {curr_location.Longitude},{curr_location.Latitude}\nVEHICLE_TYPE: {vehicle.Type}\nVEHICLE_MODEL: {vehicle.Model}\nVEHICLE_LICENCE_PLATE: {vehicle.Licence_Plate}\nAVERAGE_RATING: {rating_avg}\nAVAILABILITY: {availability}";
            return driver;
        }
        
        public Driver()
        {
            driver_id = generate_id();
            vehicle = new Vehicle();
            curr_location = new Location();
            rating =new List<int> {0};
        }
        public void printDriver()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Driver ID is: {driver_id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"PhoneNo: {phoneNo}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Vehicle Type: {vehicle.Type}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Licence PLATE: {vehicle.Licence_Plate}");
            Console.WriteLine($"CURRENT LOCATION: {curr_location.Longitude},{curr_location.Latitude}");
            Console.WriteLine("Your Rating: ");
            foreach(int i in rating)
            {
                Console.WriteLine(i);
            }
            double driver_rating = getRating();
            Console.WriteLine($"Your Average rating is: {driver_rating}");
            Console.WriteLine($"Availability: {availability}");
        }
        public  int generate_id()
        {
            ++id;
            //Console.WriteLine(id);
            return id;
        }
       
        public void updateAvailability()
        {
            Console.WriteLine("If You're Availabe, Enter 1: \nIf You're UnAvailable, Enter 0\n Enter: ");
            Console.ForegroundColor = ConsoleColor.Green; // set color to green
            string status = Console.ReadLine();
            int status1 = int.Parse(status);
            if (status1 == 1)
            {
                this.availability = true;
            }
            if(status1 == 0)
            {
                this.availability = false;
            }
        }
        public double getRating()
        {
            if (this.rating.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach (int r in this.rating)
            {
                sum += r;
            }
            return sum / this.rating.Count;
        }
        public void updateLocation()
        {
            Console.WriteLine("Please enter your current location: ");
            Console.WriteLine("Enter longitude: ");
            string longitude1 = Console.ReadLine();
            float longitude = float.Parse(longitude1);
            Console.WriteLine("Enter latitude: ");
            string latitude1 = Console.ReadLine();
            float latitude = float.Parse(latitude1);
            this.curr_location.setLocation(longitude, latitude);
        }
    }
}