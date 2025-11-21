namespace Aerodrom
{
    internal class Plane
    {
        public string name { get; set; }
        public int year { get; set; }
        public int numberOfFlights { get; set; }
        public List<Tuple<string, int>> Seats { get; set; } = new List<Tuple<string, int>>();

        public Plane(string name, int year, int numberOfflights, List<Tuple<string,int>> seats) 
        {
            this.name = name;
            this.year = year;
            this.numberOfFlights = numberOfflights;
            this.Seats = seats;
        }
    }
}
