namespace Aerodrom
{
    internal class Flight
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public double distance { get; set; }
        public double duration { get; set; }
        public int crew { get; set; } 
    }
}
