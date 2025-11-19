namespace Aerodrom
{
    internal class Planes : Funcionality
    {
        public int id;
        public string name;
        public int year;
        public int NumberOfFlights;

        public void AddPlane()
        {

        }

        public void DeletePlane(int id)
        {

        }

        public void SearchPlane(int id)
        {

        }

        public void ListPlanes()
        {

        }

        public static int PlanesMenuInput()
        {
            Console.Clear();
            Console.Write("Avioni \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih aviona \n 2-Dodavanje novog aviona " +
                "\n 3-Pretraživanje aviona \n 4-Brisanje aviona " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 4);
            return input;
        }
    }
}
