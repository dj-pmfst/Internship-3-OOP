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
            int crewId = InputValid("Unesite ID posade: ", crew.Crews.Count);

            Console.WriteLine("Uspješno registriran let {0}", name);

            return new Flight
            {
                id = nextId,
                name = name,
                departure = departure,
                arrival = arrival,
                distance = distance,
                duration = duration,
                crew = crewId
            };
        }

        public void AddFlight()
        {
            var newFlight = RegisterFlight();
            Trips[nextId] = newFlight;
            nextId++;
        }

        public void SearchFlights()
        {
            Console.Clear();
            Console.Write("Pretraživanje letova \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Po ID-u \n 2-Po nazivu " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 2);

            if (input == 1)
            {
                // dodat da izlista sve letove
                var idInput = InputValid("Unesite ID: ", Trips.Count());
                foreach (var trip in Trips)
                {
                    if (idInput == trip.Key)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                        "- Datum polaska: {3} - Datum dolaska: {4} " +
                        "- Vrijeme putovanja: {5} h \n",
                        trip.Key, trip.Value.name, trip.Value.distance, trip.Value.arrival, trip.Value.departure,
                        trip.Value.duration);
                    }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema letova s unesenim ID-em. " +
                            "\nPritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                    }
                }
            }
            else if (input == 2)
            {
                var nameInput = NameValid("Unesite naziv leta: ", "name");
                foreach (var trip in Trips)
                {
                    if (nameInput == trip.Value.name)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                        "- Datum polaska: {3} - Datum dolaska: {4} " +
                        "- Vrijeme putovanja: {5} h \n",
                        trip.Key, trip.Value.name, trip.Value.distance, trip.Value.arrival, trip.Value.departure,
                        trip.Value.duration);
                    }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema letova s unesenim nazivom. " +
                            "\nPritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                    }
                } //moglo bi se ovo pojednostavnit s obzirom da su oba searcha na isti princip.. mozda jedna funkcija u functionality za sve searcheve? 
            }
            else if (input == 0)
            {
                FlightsMenuInput();
            }
        }

        public void EditFlight()
        {
            Console.Clear(); //printat sve letove
            var idInput = InputValid("Uređivanje leta \n \nUnesite ID leta kojeg zelite urediti: ", Trips.Count()); //ispis ako uneseni id ne postoji ? 
            var confirm = Confirmation(idInput, "uređivanje");

            if (confirm == true)
            {
                Console.Write("Unesite novo vrijeme polaska: ");
                Trips[idInput].arrival = DateValid(Console.ReadLine());
                Console.Write("Unesite novo vrijeme dolaska: ");
                Trips[idInput].departure = DateValid(Console.ReadLine());
                Trips[idInput].crew = InputValid("Unesite ID nove posade: ", crew.Crews.Count);

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
            foreach (var trip in Trips)
            {
                Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                    "- Datum polaska: {3} - Datum dolaska: {4} " +
                    "- Vrijeme putovanja: {5} h \n",
                    trip.Key, trip.Value.name, trip.Value.distance, trip.Value.arrival, trip.Value.departure,
                    trip.Value.duration);
            }
            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static int FlightsMenuInput()
        {
            Console.Clear();
            Console.Write("Letovi \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih letova \n 2-Dodavanje leta " +
                "\n 3-Pretraživanje letova \n 4-Uređivanje leta " +
                "\n 5-Brisanje leta \n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 5);
            return input;
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
    }
}
