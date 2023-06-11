using DriverLibrary;
using VehicleLibrary;
using LocationLibrary;
using System;
using System.Security.Policy;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace AdminLibrary
{
    public class Admin
    {
        public static List<Driver> driverList = new List<Driver>();
        public void printDriverList()
        {
            foreach (Driver driver in driverList)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"ID: {driver.driver_id}");
                Console.WriteLine($"Name: {driver.name}");
                Console.WriteLine($"Age: { driver.age}");
                Console.WriteLine($"GENDER: { driver.gender}");
                Console.WriteLine($"Phone Number: { driver.phoneNo}");
                Console.WriteLine($"Current Location: { driver.curr_location.Longitude},{driver.curr_location.Latitude}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public Driver addDriver()
        {
            
            Driver driver = new Driver ();
            Console.WriteLine("Enter Your Name: ");
            Console.ForegroundColor = ConsoleColor.Green; // set color to green
            driver.Name = Console.ReadLine();
            Console.WriteLine("Enter Your Age: ");
            string age1 = Console.ReadLine();
            driver.Age = int.Parse(age1);
            Console.WriteLine("Enter Your Phone Number: ");
            driver.PhoneNo = Console.ReadLine();
            Console.WriteLine("Enter Your Gender: ");
            driver.Gender = Console.ReadLine();
            Console.WriteLine("Enter Your Address: ");
            driver.Address = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Type <<Rickshaw>>\n<<Bike>>\n<<Car>>: ");
            driver.vehicle.Type = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Model: ");
            driver.vehicle.Model = Console.ReadLine();
            Console.WriteLine("Enter Vehicle License Plate: ");
            driver.vehicle.Licence_Plate = Console.ReadLine();
            Console.WriteLine("Enter your Current Location i.e:1,2 : ");
            string current_loc = Console.ReadLine();
            string[] curr_loc = current_loc.Split(',');
            driver.curr_location.Longitude = float.Parse(curr_loc[0]);
            driver.curr_location.Latitude = float.Parse(curr_loc[1]);
            driverList.Add(driver);
            Console.WriteLine(driver.driver_id);
            Console.WriteLine(Admin.driverList.Count);
            //searchDriver();
            

            Console.WriteLine("----------------------------------------------------");
            return driver;
            
        }
        public void removeDriver()
        {
            Console.WriteLine("Enter your Driver ID: ");
            string id_driver = Console.ReadLine();
            int driver_id = int.Parse(id_driver);
            foreach (Driver driver in driverList)
            {
                if (driver.driver_id == driver_id)
                {
                    //driver.driver_id = 0;
                    //driver.name = "";
                    //driver.curr_location.setLocation(0, 0);
                    //driver.vehicle.Licence_Plate = "";
                    //driver.vehicle.Model = "";
                    //int count = driver.vehicle.Type.Count();
                    //driver.vehicle.Type.Remove(0,count);
                    //driver.phoneNo = "";
                    //driver.age = 0;
                    //driver.gender = "";
                    //driver.rating.Clear();
                    //driver.availability = false;
                    driverList.RemoveAt(0);
                    printDriverList();

                    //bool ans = driverList.Remove(driver);
                    //if(ans == true)
                    //{
                     Console.WriteLine("REMOVED");
                    //}
                }
            }
        }
        public Dictionary<string, string> updateDriver(List<Driver> driver_list)
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            data.Add("Id", "");
            data.Add("Name", "");
            data.Add("Age", "");
            data.Add("Gender", "");
            data.Add("Address", "");
            data.Add("PhoneNo","");
            data.Add("Vehicle.Type", "");
            data.Add("Vehicle.Model", "");
            data.Add("Vehicle.Licence_Plate", "");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the Id of driver : ");
            Console.ForegroundColor = ConsoleColor.Green;
            string driver_id0 = Console.ReadLine();
            int driver_id1 = int.Parse(driver_id0);
            int i = 0;
            foreach (Driver driver in driver_list)
            {
                if (driver.driver_id == driver_id1)
                {
                    data["Id"]= System.Convert.ToString(driver.driver_id);
                    i = i + 1;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"-----------------DRIVER WITH ID {driver.driver_id} exists------------------- ");
                    Console.WriteLine($"Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        driver.name = name;
                        data["Name"]= name;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string age1 = Console.ReadLine();
                    
                    if(string.IsNullOrEmpty(age1))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Age"] =age1;
                        int age11 = int.Parse(age1);
                        driver.age = age11;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string gender = Console.ReadLine();
                    if (string.IsNullOrEmpty(gender))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Gender"]= gender;
                        driver.gender = gender;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"PhoneNo: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string phone_num = Console.ReadLine();
                    if (string.IsNullOrEmpty(phone_num))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["PhoneNo"]= phone_num;
                        driver.phoneNo = phone_num;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    if (string.IsNullOrEmpty(address))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Address"]= address;
                        driver.address = address;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Vehicle Type: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicle_type = Console.ReadLine();
                    if (string.IsNullOrEmpty(vehicle_type))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Vehcile.Type"] =vehicle_type;
                        driver.vehicle.Type = vehicle_type;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicle_model = Console.ReadLine();
                    if (string.IsNullOrEmpty(vehicle_model))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Vehicle.Model"]= vehicle_model;
                        driver.vehicle.Model = vehicle_model;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Licence PLATE: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string licence_plate = Console.ReadLine();
                    if (string.IsNullOrEmpty(licence_plate))
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        data["Vehicle.Licence_Plate"]= licence_plate;
                        driver.vehicle.Licence_Plate = licence_plate;
                    }
                    Console.WriteLine("-----------UPDATED DATA IS:---------------");
                    driver.printDriver();

                    return data; 
                }  
            }
            if(i == 0)
            {
                Console.WriteLine("ID not found!!!");
            }
            return data;
        }
        public void searchDriver(List<Driver> drivers)
        {
            Console.WriteLine("Enter ID: ");
            int driver_ID = 0;
            string driverId = Console.ReadLine();
            if (string.IsNullOrEmpty(driverId))
            {
                Console.WriteLine(" ");
            }
            else
            {
                driver_ID = int.Parse(driverId);
            }
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            if(string.IsNullOrEmpty(name))
            {
                Console.WriteLine(" ");
            }

            Console.WriteLine("Enter Age: ");
            string age1 = Console.ReadLine();
            int age = 0;
            if (string.IsNullOrEmpty(age1))
            {
                
                Console.WriteLine(" ");
            }
            else
            {
                age = int.Parse(age1);
            }

            Console.WriteLine("Enter Gender: ");
            string gender = Console.ReadLine();
            if (string.IsNullOrEmpty(gender))
            {
                Console.WriteLine(" ");
            }

            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();
            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine(" ");
            }

            Console.WriteLine("Enter VehicleType: ");
            string vehicleType = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleType))
            {
                Console.WriteLine(" ");
            }

            Console.WriteLine("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            if (string.IsNullOrEmpty(vehicleModel))
            {
                Console.WriteLine(" ");
            }

            Console.WriteLine("Enter Licence Plate: ");
            string licencePlate = Console.ReadLine();
            if (string.IsNullOrEmpty(licencePlate))
            {
                Console.WriteLine(" ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Driver driver in drivers)
            {
                if (driver.driver_id == driver_ID || driver.Name == name || driver.Age == age || driver.Address == address || driver.Gender == gender || driver.vehicle.Type == vehicleType || driver.vehicle.Model == vehicleModel || driver.vehicle.Licence_Plate == licencePlate)
                {
                    Console.Write("-------------------------------------------------------------------------------------\n");
                    Console.WriteLine($"Name\tAGE\tGender\tV.Type\t\tV.Model\t\tV.LicencePlate");
                    Console.WriteLine($"{driver.name}\t{driver.age}\t{driver.gender}\t{driver.vehicle.Type}\t\t{driver.vehicle.Model}\t\t{driver.vehicle.Licence_Plate}");
                }
            }


        }
    }
}