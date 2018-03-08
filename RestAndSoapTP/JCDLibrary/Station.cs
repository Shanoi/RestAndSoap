using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    [DataContract]
    public class Station
    {
        
        private string name;


        [DataMember]
        public string Address { get => address; set => address = value; }
        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Status { get => status; set => status = value; }
        [DataMember]
        public int Available_bike_stands { get => available_bike_stands; set => available_bike_stands = value; }
        [DataMember]
        public int Available_bikes { get => available_bikes; set => available_bikes = value; }
        
        private string address;
    
        private string status;
  
        private int available_bike_stands;

        private int available_bikes;

        public Station(string name, string address, string status,
            int available_bike_stands, int available_bikes)
        {
            this.Name = name;
            this.Address = address;
            this.Status = status;
            this.Available_bike_stands = available_bike_stands;
            this.Available_bikes = available_bikes;
        }
        public override string ToString()
        {
            return "Nom : " + Name + "\n"
                + "Status : " + Status + "\n"
                + "Address : " + Address + "\n"
                + "Available bike stands : " + Available_bike_stands + "\n"
                + "Available bikes : " + Available_bikes;
        }

    }
}
