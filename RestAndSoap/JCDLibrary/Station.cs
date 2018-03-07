using System.Runtime.Serialization;

namespace JCDLibrary
{

    [DataContract]
    public class Station
    {
        [DataMember]
        private string name;

        [DataMember]
        public string Name
        {
            get { return name; }
        }

        [DataMember]
        private string address;
        [DataMember]
        private string status;
        [DataMember]
        private int available_bike_stands;
        [DataMember]
        private int available_bikes;

        public Station(string name, string address, string status,
            int available_bike_stands, int available_bikes)
        {
            this.name = name;
            this.address = address;
            this.status = status;
            this.available_bike_stands = available_bike_stands;
            this.available_bikes = available_bikes;
        }
        public override string ToString()
        {
            return "Nom : " + name + "\n"
                + "Status : " + status + "\n"
                + "Address : " + address + "\n"
                + "Available bike stands : " + available_bike_stands + "\n"
                + "Available bikes : " + available_bikes;
        }

    }
}