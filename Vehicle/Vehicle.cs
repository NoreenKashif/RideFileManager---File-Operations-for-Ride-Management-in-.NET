using System.Xml.Schema;

namespace VehicleLibrary
{
    public class Vehicle
    {
        private string type;
        private string model;
        private string licence_plate;
        public string Type   // public property
        {
            get { return type; }
            set 
            {
                value = value.ToLower();
                if (value == "bike" || value == "rickshaw" || value == "car")
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException("Invalid vehicle type: " + value);
                }
            }
        }
        public string Model
        {
            get { return model; }
            set{ model = value;  }
        }
        public string Licence_Plate
        {
            get { return licence_plate; }
            set { licence_plate = value; }
        }
    }
}