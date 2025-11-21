namespace Aerodrom
{
    internal class Flight
    {
        public string name { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public double distance { get; set; }
        public double duration { get; set; }
        public int crewId { get; set; }

        public Flight(string name, DateTime departure, DateTime arrival, double distance, double duration, int crewId)
        {
            this.name = name;
            this.departure = departure;
            this.arrival = arrival;
            this.distance = distance;
            this.duration = duration;
            this.crewId = crewId;
        }

    }
}
