namespace Aerodrom
{
    internal class Planes : Funcionality
    {
        private int nextId = 0;
        public Dictionary<int, Plane> Airplanes { get; set; } = new Dictionary<int, Plane>();

        private Plane RegisterPlane()
        {
            Console.Clear();
            Console.Write("Dodavanje aviona \n \n ");

            Console.Write("Unesite ime: ");
            string name = NameValid(Console.ReadLine(), "name");
            Console.Write("Unesite godinu proizvodnje: ");
            DateTime year = DateValid(Console.ReadLine());

            Console.WriteLine("Uspješno registriran avion {0}", name);

            return new Plane(name, year.Year, 0, seats);
        }

        public void AddPlane()
        {
            var newPlane = RegisterPlane();
            Airplanes[nextId] = newPlane;
            nextId++;
        }

        public void DeletePlane()
        {
            var input = Menus.SearchMenu("Brisanje aviona");

            if (input == 1)
            {
                // dodat da izlista sve letove
                var idInput = InputValid("Unesite ID. ", Airplanes.Count());
                var confirm = Confirmation(idInput, "brisanje");
                if (confirm == true)
                {
                    Airplanes.Remove(idInput);
                }
            }

            else if (input == 2)
            {
                int planeId = -1;
                Console.Write("Unesite naziv aviona: ");
                var nameInput = NameValid(Console.ReadLine(), "name");
                foreach (var plane in Airplanes)
                {
                    if (plane.Value.name == nameInput) { planeId = plane.Key; }
                }
                if (planeId == -1) 
                { 
                    Console.WriteLine("Ne postoji avion s unesenim ID-em."); 
                    Continue();
                } 
                else 
                { 
                    var confirm = Confirmation(planeId, "brisanje"); 
                    Airplanes.Remove(planeId);
                }
            }
            else if (input == 0)
            {
                Menus.PlanesMenuInput();
            }
        }

        public void SearchPlane()
        {
            int input = Menus.SearchMenu("Pretraživanje aviona");

            if (input == 1)
            {
                // dodat da izlista sve letove
                var idInput = InputValid("Unesite ID. ", Airplanes.Count());
                foreach (var plane in Airplanes)
                {
                    if (idInput == plane.Key)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Godina proizvodnje: {2} " +
                        "- Broj letova: {3} \n",
                        plane.Key, plane.Value.name, plane.Value.year, plane.Value.numberOfFlights);
                    }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema aviona s unesenim ID-em. ");
                        Continue();
                    }
                }
            }
            else if (input == 2)
            {
                Console.Write("Unesite naziv aviona: ");
                var nameInput = NameValid(Console.ReadLine(), "name");
                foreach (var plane in Airplanes)
                {
                    if (nameInput == plane.Value.name)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Godina proizvodnje: {2} " +
                        "- Broj letova: {3} \n",
                        plane.Key, plane.Value.name, plane.Value.year, plane.Value.numberOfFlights);
                    }
                    else
                    { /// 
                        Console.WriteLine("Nema aviona s unesenim nazivom. ");
                        Continue();
                    }
                } //moglo bi se ovo pojednostavnit s obzirom da su oba searcha na isti princip.. mozda jedna funkcija u functionality za sve searcheve? 
            }
            else if (input == 0)
            {
                Menus.PlanesMenuInput();
            }
        }

        private void ListPlanes()
        {
            Console.Clear();
            Console.Write("Prikaz svoh aviona \n \n ");
            foreach (var plane in Airplanes)
            {
                Console.WriteLine("ID: {0} - Naziv: {1} - Godina proizvodnje: {2} " +
                "- Broj letova: {3} \n",
                plane.Key, plane.Value.name, plane.Value.year, plane.Value.numberOfFlights);
            }
            Continue();
        }

        public void PlanesMenu(int input)
        {
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
