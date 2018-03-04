namespace JCDLibrary
{
    internal class Station
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        private string address;
        private string status;
        private int available_bike_stands;
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