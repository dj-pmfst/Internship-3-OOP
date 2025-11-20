namespace Aerodrom
{
    internal class CrewMember
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string position { get; set; }
        public string gender { get; set; }

        public CrewMember (string name, string surname, DateTime dob, string position, string gender)
        {
            this.name = name;
            this.surname = surname;
            this.dob = dob;
            this.position = position;
            this.gender = gender;
        }
    }
}
