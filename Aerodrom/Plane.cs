namespace Aerodrom
{
    internal class Plane
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public int numberOfFlights { get; set; }
        List<Tuple<string, int>> Seats { get; set; } = new List<Tuple<string, int>>();
    }
}
