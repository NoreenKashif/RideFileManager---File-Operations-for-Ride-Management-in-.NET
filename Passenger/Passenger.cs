namespace PassengerLibrary
{
    public class Passenger
    {
        private string name { get; set; }
        private string phone_no { get; set; }
        public Passenger()
        {
            name = "";
            phone_no = "";
        }

        public Passenger(string name, string phone_number)
        {
            this.name = name;
            this.phone_no = phone_number;

        }
    }
}