using System.Numerics;

namespace Aerodrom
{
    internal class Planes : Funcionality
    {
        public static List<int> planeId = ID(2);
        public static Dictionary<int, Plane> Airplanes { get; set; } = new Dictionary<int, Plane>();

        private Plane RegisterPlane()
        {
            var seats = new List<Tuple<string, int>>();

            Console.Clear();
            Console.Write("Dodavanje aviona \n \n ");

            string name = GetInput("ime: ", s=> PlaneValid(s)); ;
            DateTime year = GetInput("datum proizvodnje: ",s => DateValid(s));
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
            var nextId = planeId.LastOrDefault()+1;
            Airplanes[nextId] = newPlane;
            planeId.Add(nextId);

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
                    var idInput = idValid("Unesite ID. ", planeId, "0").ToString();
                    DeleteHelper(idInput);
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
            int id = -1;
            var nameInput = input;
            var idInput = input;
            foreach (var plane in Airplanes)
            {
                if (plane.Value.name == nameInput || plane.Key.ToString() == idInput) { id = plane.Key; }
            }
            if (id == -1)
            {
                Console.WriteLine("Ne postoji avion s unesenim nazivom.");
                Continue();
            }
            else
            {
                var confirm = Confirmation(id, "brisanje");
                Airplanes.Remove(id);
                planeId.RemoveAll(x => x == id);
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
            if (type == "ID") { idInput = idValid("Unesite ID", planeId, "search"); }
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

        private void SortByYear(string type)
        {
            Console.Clear();
            List<KeyValuePair<int, Plane>> sortedPlanes = new List<KeyValuePair<int, Plane>>();

            if (type == "up")
            {
                Console.WriteLine("Ispis svih aviona prema godini proivodnje uzlazno \n \n");
                sortedPlanes = Airplanes.OrderBy(p => p.Value.year).ToList();
            }
            else if (type == "down")
            {
                Console.WriteLine("Ispis svih aviona prema godini proivodnje silazno \n \n");
                sortedPlanes = Airplanes.OrderByDescending(p => p.Value.year).ToList();
            }
            foreach (var plane in sortedPlanes) { Print(plane); }
            Continue ();
            SortPlanes();
        }

        private void SortByFlight(string type)
        {
            Console.Clear();
            List<KeyValuePair<int, Plane>> sortedPlanes = new List<KeyValuePair<int, Plane>>();

            if (type == "up")
            {
                Console.WriteLine("Ispis svih aviona prema broju letova uzlazno \n \n");
                sortedPlanes = Airplanes.OrderBy(p => p.Value.flights.Count).ToList();
            }
            else if (type == "down")
            {
                Console.WriteLine("Ispis svih aviona prema broju letova silazno \n \n");
                sortedPlanes = Airplanes.OrderByDescending(p => p.Value.flights.Count).ToList();
            }
            foreach (var plane in sortedPlanes) { Print(plane); }
            Continue();
            SortPlanes();
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
                case 5: SortPlanes(); break;
            }
        }

        private void SortPlanes()
        {
            int input = Menus.SortPlanesInput();
            switch (input)
            {
                case 0: PlanesMenu(); break;
                case 1: ListPlanes(); break;
                case 2: SortByYear("up"); break;
                case 3: SortByYear("down"); break;
                case 4: SortByFlight("up"); break;
                case 5: SortByFlight("down"); break;
            }
        }
    }
}
