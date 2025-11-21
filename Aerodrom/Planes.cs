using System.Numerics;

namespace Aerodrom
{
    internal class Planes : Funcionality
    {
        private int nextId = 3;
        public static Dictionary<int, Plane> Airplanes { get; set; } = new Dictionary<int, Plane>();

        private Plane RegisterPlane()
        {
            var seats = new List<Tuple<string, int>>();

            Console.Clear();
            Console.Write("Dodavanje aviona \n \n ");

            string name = GetInput("Unesite ime: ", s=> PlaneValid(s)); ;
            DateTime year = GetInput("Unesite datum proizvodnje: ",s => DateValid(s));
            Console.Write("Unesite broj sjedala u economy razredu: ");
            int economy = (int)NumberValid(Console.ReadLine());
            Console.Write("Unesite broj sjedala u bussines razredu: ");
            int bussines = (int)NumberValid(Console.ReadLine());

            Console.WriteLine("Uspješno registriran avion {0}", name);

            seats = new List<Tuple<string, int>>() { Tuple.Create("economy", economy), Tuple.Create("business", bussines) };
            return new Plane(name, year.Year, new List<int>(), seats);
        }

        public void AddPlane()
        {
            var newPlane = RegisterPlane();
            Airplanes[nextId] = newPlane;
            nextId++;

            Continue();
            PlanesMenu();
        }

        public void DeletePlane()
        {
            var input = Menus.SearchMenu("Brisanje aviona \n \n");
            if (Airplanes.Count != 0)
            {
                foreach (var plane in Airplanes) { Print(plane); }

                if (input == 1)
                {
                    var idInput = InputValid("Unesite ID. ", nextId);
                    DeleteHelper($"\"idInput\"");
                }

                else if (input == 2)
                {
                    Console.Write("Unesite naziv aviona: ");
                    var nameInput = Console.ReadLine();
                    DeleteHelper(nameInput);
                }
                else if (input == 0) { Continue(); }
            }
            else { Console.WriteLine("Nema registriranih aviona."); }
            PlanesMenu();
        }

        private void DeleteHelper(string input)
        {
            int planeId = -1;
            var nameInput = input;
            var idInput = input;
            foreach (var plane in Airplanes)
            {
                if (plane.Value.name == nameInput || plane.Key.ToString() == idInput) { planeId = plane.Key; }
            }
            if (planeId == -1)
            {
                Console.WriteLine("Ne postoji avion s unesenim nazivom.");
                Continue();
            }
            else
            {
                var confirm = Confirmation(planeId, "brisanje");
                Airplanes.Remove(planeId);
            }
        }

        public void SearchPlane()
        {
            int input = Menus.SearchMenu("Pretraživanje aviona \n \n");

            if (input == 1) { SearchShow("ID"); }
            else if (input == 2) { SearchShow("naziv"); }
            else if (input == 0) { PlanesMenu(); }
        }

        private void SearchShow(string type)
        {
            int idInput = -1;
            string nameInput = "0";
            if (type == "ID") { idInput = InputValid("Unesite ID", nextId); }
            else if (type == "naziv")
            {
                Console.Write("Unesite ime: ");
                nameInput = Console.ReadLine();
            }
            foreach (var plane in Airplanes)
            {
                if (idInput == plane.Key) { Print(plane); idInput = plane.Key; }
                if (nameInput == plane.Value.name) { Print(plane); idInput = plane.Key; }
            }
            if (idInput == -1) { Console.WriteLine($"Nema aviona s unesenim {type}om", type); }
            Continue();
            PlanesMenu();
        }

        private void ListPlanes()
        {
            Console.Clear();
            Console.Write("Prikaz svih aviona \n \n");
            if (Airplanes.Count != 0)
            {
                foreach (var plane in Airplanes) { Print(plane); }
            }
            else { Console.WriteLine("Nema registriranih aviona."); }
            Continue();
            PlanesMenu();
        }

        private void Print(KeyValuePair<int, Plane> plane)
        {
            Console.WriteLine("ID: {0} - Naziv: {1} - Godina proizvodnje: {2} " +
            "- Broj letova: {3} \n",
            plane.Key, plane.Value.name, plane.Value.year, plane.Value.flights.Count());
        }

        public void PlanesMenu()
        {
            int input = Menus.PlanesMenuInput();
            switch (input)
            {
                case 0: break;
                case 1: ListPlanes(); break;
                case 2: AddPlane(); break;
                case 3: SearchPlane(); break;
                case 4: DeletePlane(); break;
            }
        }
    }
}
