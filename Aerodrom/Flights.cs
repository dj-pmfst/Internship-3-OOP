namespace Aerodrom
{
    internal class Flights : Funcionality
    {
        private int nextId = 0;

        private Crew crew;
        public Dictionary<int, Flight> Trips { get; set; } = new Dictionary<int, Flight>();
        public Flights(Crew c)
        {
            crew=c;
        }

        public Flight RegisterFlight()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje letova \n \n");
            Console.Write("Unesite ime: ");
            string name = NameValid(Console.ReadLine(), "name");
            Console.Write("Unesite datum polaska: ");
            DateTime departure = DateValid(Console.ReadLine());
            Console.Write("Unesite datum dolaska: ");
            DateTime arrival = DateValid(Console.ReadLine());
            Console.Write("Unesite udaljenost: ");
            double distance = NumberValid(Console.ReadLine());
            Console.Write("Unesite vrijeme putovanja: ");
            double duration = NumberValid(Console.ReadLine());
            int crewId = InputValid("Unesite ID posade. ", crew.Crews.Count);

            Console.WriteLine("Uspješno registriran let {0}", name);

            return new Flight(name, departure, arrival, distance, duration, crewId);
        }

        public void AddFlight()
        {
            var newFlight = RegisterFlight();
            Trips[nextId] = newFlight;
            nextId++;
        }

        public void SearchFlights()
        {
            var input = Menus.SearchMenu("Pretraživanje letova");

            if (input == 1)
            {
                // dodat da izlista sve letove
                var idInput = InputValid("Unesite ID. ", Trips.Count());
                foreach (var trip in Trips)
                {
                    if (idInput == trip.Key) { Print(trip); }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema letova s unesenim ID-em. ");
                        Continue(); 
                    }
                }
            }
            else if (input == 2)
            {
                var nameInput = NameValid("Unesite naziv leta: ", "name");
                foreach (var trip in Trips)
                {
                    if (nameInput == trip.Value.name) { Print(trip); }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema letova s unesenim nazivom. ");
                        Continue();
                    }
                } //moglo bi se ovo pojednostavnit s obzirom da su oba searcha na isti princip.. mozda jedna funkcija u functionality za sve searcheve? 
            }
            else if (input == 0)
            {
                Menus.FlightsMenuInput();
            }
        }

        public void EditFlight()
        {
            Console.Clear(); //printat sve letove
            Console.WriteLine("Uređivanje leta \n \n");
            var idInput = InputValid("Unesite ID leta kojeg zelite urediti. ", Trips.Count()); //ispis ako uneseni id ne postoji ? 
            var confirm = Confirmation(idInput, "uređivanje");

            if (confirm == true)
            {
                Console.Write("Unesite novo vrijeme polaska: ");
                Trips[idInput].arrival = DateValid(Console.ReadLine());
                Console.Write("Unesite novo vrijeme dolaska: ");
                Trips[idInput].departure = DateValid(Console.ReadLine());
                Trips[idInput].crewId = InputValid("Unesite ID nove posade. ", crew.Crews.Count);

                //u biti nema smisla da se ranije printa jel uspjenso uredeno
                //al nez kako popravit bez da sve pastean ovdi
            }
        }
        
        public void DeleteFlight()
        {
            Console.Clear(); //honestly ovo i uredivanje bi mogla bit jedna fja. tj bar pola njihove funkcionalnosti
            var idInput = InputValid("Brisanje leta \n \nUnesite ID leta kojeg zelite izbrisati: ", Trips.Count()); //ispis ako uneseni id ne postoji ? 
            var confirm = Confirmation(idInput, "brisanje");

            if (confirm == true) 
            {
                Trips.Remove(idInput);
            }
        }

        public void ListFlights()
        {
            foreach (var trip in Trips) { Print(trip); }
            Continue();
        }

        public void FlightsMenu(int input)
        {
            switch (input)
            {
                case 0: break;
                case 1: ListFlights(); break;
                case 2: AddFlight(); break;
                case 3: SearchFlights(); break;
                case 4: DeleteFlight(); break;
            }
        }

        public void Print(KeyValuePair<int,Flight> trip)
        {
            Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
            "- Datum polaska: {3} - Datum dolaska: {4} " +
            "- Vrijeme putovanja: {5} h \n",
            trip.Key, trip.Value.name, trip.Value.distance, trip.Value.arrival, trip.Value.departure,
            trip.Value.duration);
        }
    }
}
