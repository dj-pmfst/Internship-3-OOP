namespace Aerodrom
{
    internal class Crew : Funcionality
    {
        public string CrewName;
        public Dictionary<int, CrewMember> CrewMembers { get; set; } = new Dictionary<int, CrewMember>();


        public void AddCrew()
        {

        }

        public void AddCrewMember()
        {

        }

        public static int CrewMenuInput()
        {
            Console.Clear();
            Console.Write("Posada \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih posada \n 2-Kreiranje nove posade " +
                "\n 3-Dodavanje osobe \n 0-Povratak na prethodni izbornik";

            var firstInput = InputValid(menuText, 3);

            return firstInput;
        }
    }
}
