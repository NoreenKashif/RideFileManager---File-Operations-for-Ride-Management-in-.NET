using AdminLibrary;
using DriverLibrary;
using LocationLibrary;
using RideLibrary;
using FileOperations;


namespace MyRide
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void mainMenu()
            {
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("                                     WELCOME      TO      MY       RIDE");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("1.   Book a Ride");
                Console.WriteLine("2.   Enter as Driver");
                Console.WriteLine("3.   Enter as Admin");
                Console.WriteLine("Please 1 to 3 to select an option: ");
                Console.ForegroundColor = ConsoleColor.Green;

                string option = Console.ReadLine();
                int option1 = int.Parse(option);
                //return option1;
                MYRIDEDAL file_operations = new MYRIDEDAL();
                List<Driver> driverList = file_operations.readAll();
                
                if (option1 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("BOOK A RIDE");
                    Ride ride = new Ride();
                    ride.assignPassenger();
                    //ASKING FOR START LOCATION OF THE PASSENGER
                    Location start_location1 = new Location();
                    Console.WriteLine("Enter your Start Location i.e:1,2 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string current_loc = Console.ReadLine();
                    //Console.WriteLine(current_loc);
                    string[] curr_loc = current_loc.Split(',');
                    start_location1.Longitude = float.Parse(curr_loc[0]);
                    start_location1.Latitude = float.Parse(curr_loc[1]);
                    //Console.WriteLine($"{curr_loc[1]}");

                    //ASKING FOR END LOCATION OF THE PASSENGER
                    Location end_location1 = new Location();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter your End Location i.e:1,2 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string end_loc = Console.ReadLine();
                    //Console.WriteLine(end_loc);
                    string[] end_loc1 = end_loc.Split(',');
                    end_location1.Longitude = float.Parse(end_loc1[0]);
                    end_location1.Latitude = float.Parse(end_loc1[1]);

                    //SETTING LOCATION TO A RIDE OBJECT
                    ride.setLocation(start_location1, end_location1);
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    //ASKING FOR RIDE TYPE
                    Console.WriteLine("Enter Ride Type: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string rideType = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-----------------THANK YOU-------------------");

                    //CALCULATING THE PRICE OF THE RIDE
                    double price_of_the_ride = ride.calculatePrice(rideType);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Price for this Ride is: {price_of_the_ride}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string opt = Console.ReadLine();
                    opt = opt.ToUpper();
                    if (opt == "Y")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("HAPPY TRAVEL...!");
                        //GIVING LIST Of Drivers to Assign Drivers From file
                        Driver driver = ride.assignDriver(driverList, rideType);
                        Console.WriteLine("Rate this Ride: ");
                        string pass_rating = Console.ReadLine();//give ratings
                        int passenger_rating = int.Parse(pass_rating);
                        driver.rating.Add(passenger_rating);//admin list of drivers to assign driver                     
                    }
                }
                if (option1 == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter As Driver");
                    Console.WriteLine("Enter ID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string id = Console.ReadLine();
                    int dri_id = int.Parse(id);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
       
                    //Console.WriteLine(driverList);
                    foreach (Driver driver in driverList)
                    {
                        //Console.WriteLine("0999");
                        if(dri_id == driver.driver_id)
                        {
                            //Console.WriteLine("{0} {1}",dri_id,driver.driver_id);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"Hello, {driver.Name}");
                            file_operations.updateCurrLocation(dri_id);
                            Console.WriteLine("1. Change Availability: ");
                            Console.WriteLine("2. Change Location: ");
                            Console.WriteLine("Enter Choice, either <<< 1 >>> or <<< 2 >>>");
                            string choice = Console.ReadLine();
                            int choice1 = int.Parse(choice);
                            if (choice1 == 1)
                            {
                                file_operations.updateDriverAvailabiliy(dri_id);
                                mainMenu();
                            }
                            else
                            {
                                file_operations.updateCurrLocation(dri_id);
                                mainMenu();
                            }
                            return;
                        }
                    }

                }




                if (option1 == 3)
                {
                    Admin admin_N = new Admin();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("1. Add Driver\r\n 2. VIEW ALL DRIVERS\r\n 3. Remove Driver\r\n4. Update Driver\r\n5. Search Driver\r\n6. Exit as Admin\r\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string selection = Console.ReadLine();
                    int selection1 = int.Parse(selection);
                    if (selection1 == 1)
                    {
                        
                        file_operations.addNewDriver(admin_N.addDriver());
                        //file_operation.readDriver();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Do you want to Add another?");
                        Console.WriteLine("If Yes/No?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string selec = Console.ReadLine();
                        selec = selec.ToLower();
                        while (selec == "yes")
                        {
                            file_operations.addNewDriver(admin_N.addDriver());
                            //file_operation.readDriver();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Do you want to Add another?");
                            Console.WriteLine("If Yes/No?");
                            Console.ForegroundColor = ConsoleColor.Green;
                            selec = Console.ReadLine();
                            selec = selec.ToLower();
                        }
                        foreach (Driver d in Admin.driverList)
                        {
                            d.printDriver();

                        }
                        if (selec == "no")
                        {
                            mainMenu();
                        }
                    }
                    if (selection1 == 2)
                    {
                        foreach(Driver r in driverList)
                        {
                            Console.WriteLine(r);
                        }
                        //Console.WriteLine("----------AFTER REMOVING---------");
                        //admin_N.printDriverList();
                    }
                    if (selection1 == 4)
                    {
                       Dictionary<string, string> d =  admin_N.updateDriver(driverList);
                       file_operations.updateDriver(d);

                    }
                    if (selection1 == 5)
                    {
                        
                        admin_N.searchDriver(driverList);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Wanna Search More?");
                        Console.WriteLine("If yes/no");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string choice3 = Console.ReadLine();
                        choice3 = choice3.ToLower();
                        while(choice3 == "yes")
                        {
                            admin_N.searchDriver(driverList);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Wanna Search More?");
                            Console.WriteLine("If yes/no");
                            Console.ForegroundColor = ConsoleColor.Green;
                            choice3 = Console.ReadLine();
                            choice3 = choice3.ToLower();
                        }
                        if(choice3 == "no")
                        {
                            mainMenu();
                        }

                    }
                    if (selection1 == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Bye Bye...Admin...Have a Nice DAY!!!");
                    }
                }
            }

            mainMenu();
        }
    }
}