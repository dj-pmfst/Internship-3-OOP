namespace Aerodrom
{
    internal class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<int> flights { get; set; } = new List<int>();

        public User(string name, string surname, DateTime dob, string email, string password)
        {
            this.name = name;
            this.surname = surname;
            this.dob = dob;
            this.email = email;
            this.password = password;
        }
    }

}
