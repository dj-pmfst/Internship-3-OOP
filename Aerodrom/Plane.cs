namespace Aerodrom
{
    internal class Plane
    {
        public string name { get; set; }
        public int year { get; set; }
        public List<int> flights { get; set; } = new List<int>();
        public List<Tuple<string, int>> Seats { get; set; } = new List<Tuple<string, int>>();

        public Plane(string name, int year, List<int> flights, List<Tuple<string,int>> seats) 
        {
            this.name = name;
            this.year = year;
            this.flights = flights;
            this.Seats = seats;
        }
    }
}
