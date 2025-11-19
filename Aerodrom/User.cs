namespace Aerodrom
{
    internal class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<int> flights { get; set; } = new List<int>();
    }
}
