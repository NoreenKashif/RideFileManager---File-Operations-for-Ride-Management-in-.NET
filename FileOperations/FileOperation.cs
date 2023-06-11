using AdminLibrary;
using DriverLibrary;
using LocationLibrary;
using RideLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.IO;
namespace FileOperations
{
    public class MYRIDEDAL
    {
        public void addNewDriver(Driver d)
        {
            StreamWriter add_driver = new StreamWriter("myDriverData.txt", append: true);
            //id, name, age, gender, adddress, phone_no, curr_location, vehicle, rating_list, availability
            //1, Ali, 26, MALE, LAHORE, 03054060129, 1,4, CAR, 2012, GFD 3566, 4.8, true
            string jsonString = JsonSerializer.Serialize(d);
            add_driver.WriteLine(jsonString);
            add_driver.Close();
        }
        public Driver readDriver()
        {
            StreamReader read_driver = new StreamReader("myDriverData.txt");
            string jsonString = read_driver.ReadLine();
            Driver d = JsonSerializer.Deserialize<Driver>(jsonString);
            Console.WriteLine(d);
            read_driver.Close();
            return d;

        }
        public List<Driver> readAll()
        {
            List<Driver> d = new List<Driver>();
            StreamReader readAll = new StreamReader("myDriverData.txt");
            string s = readAll.ReadLine();
            while (s != null)
            {
                Driver d1 = JsonSerializer.Deserialize<Driver>(s);
                d.Add(d1);
                s = readAll.ReadLine();
            }
            readAll.Close();
            return d;
        }
        public void updateDriver(Dictionary<string, string> updatedValues)
        {
            string id_driver = updatedValues["Id"];
            int driverId = int.Parse(id_driver);
            // Read the existing JSON from the file
            //string json = File.ReadAllText("myDriverData.txt");

            // Deserialize the JSON into a list of driver objects
            List<Driver> drivers = readAll();

            // Find the driver with the specified ID and update their information
            foreach (Driver d in drivers)
            {
                if (d.Id == driverId)
                {
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Name"])))
                    {
                        d.Name = updatedValues["Name"];
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Age"])))
                    {
                        int age = int.Parse(updatedValues["Age"]);
                        d.Age = age;
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Gender"])))
                    {
                        d.Gender = updatedValues["Gender"];
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Address"])))
                    {
                        d.Address = updatedValues["Address"];
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["PhoneNo"])))
                    {
                        d.PhoneNo = updatedValues["PhoneNo"];
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Vehicle.Type"])))
                    {
                        d.vehicle.Type = updatedValues["Vehicle.Type"];
                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Vehicle.Model"])))
                    {
                        d.vehicle.Model = updatedValues["Vehicle.Model"];

                    }
                    if (!(string.IsNullOrWhiteSpace(updatedValues["Vehicle.Licence_Plate"])))
                    {
                        d.vehicle.Licence_Plate = updatedValues["Vehicle.Licence_Plate"];
                    }

                }
            }


            // Serialize the updated list back into JSON
            //string updatedJson = JsonSerializer.Serialize(drivers, new JsonSerializerOptions { WriteIndented = false });

            // Write the updated JSON back to the file
            FileStream fs = new FileStream("myDriverData.txt", FileMode.Truncate);
            
            StreamWriter update_data = new StreamWriter(fs);
            foreach (Driver d in drivers)
            {
                update_data.WriteLine(JsonSerializer.Serialize(d));
            }

            update_data.Close();
            fs.Close();
        }
        public void updateDriverAvailabiliy(int driverId)
        {
            Console.WriteLine("Enter 1 if you're Available and 0 if you're UnAvailable: ");
            string availability = Console.ReadLine();
            int availability1 = int.Parse(availability);
            List<Driver> drivers = readAll();
            foreach (Driver d in drivers)
            {
                if (d.Id == driverId)
                {
                    if (availability1 == 1)
                    {
                        d.Availability = true;
                    }
                    if (availability1 == 0)
                    {
                        d.Availability = false;
                    }
                }
            }
            FileStream fs = new FileStream("myDriverData.txt", FileMode.Truncate);
            StreamWriter update_data = new StreamWriter(fs);
            foreach (Driver d in drivers)
            {
                update_data.WriteLine(JsonSerializer.Serialize(d));
            }

            update_data.Close();
            fs.Close();
        }
        public void updateCurrLocation(int id)
        {
            Console.WriteLine("Please enter your current location: ");
            string curr_loc = Console.ReadLine();
            string[] curr_loc1 = curr_loc.Split(',');
            string longitude1 = curr_loc1[0];
            float longitude = float.Parse(longitude1);
            string latitude1 = curr_loc1[1];
            float latitude = float.Parse(latitude1);
            List<Driver> drivers = readAll();
            foreach (Driver d in drivers)
            {
                if (d.driver_id == id)
                {
                    d.Curr_Location.Latitude = latitude;
                    d.Curr_Location.Longitude = longitude;
                }
            }
            FileStream fs = new FileStream("myDriverData.txt", FileMode.Truncate);
            StreamWriter update_data = new StreamWriter(fs);
            foreach (Driver d in drivers)
            {
                update_data.WriteLine(JsonSerializer.Serialize(d));
            }

            update_data.Close();
            fs.Close();
        }
    }
}