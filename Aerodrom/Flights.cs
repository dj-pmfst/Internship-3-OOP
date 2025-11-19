namespace Aerodrom
{
    internal class Flights : Funcionality
    {
        private int nextId = 0;
        public Dictionary<int, Flight> Trips { get; set; } = new Dictionary<int, Flight>();

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

            Console.WriteLine("Uspješno registriran let {0}", name);

            return new Flight
            {
                id = nextId,
                name = name,
                departure = departure,
                arrival = arrival,
                distance = distance,
                duration = duration,
                //crew
            };
        }

        public void AddFlight()
        {
            var newFlight = RegisterFlight();
            Trips[nextId] = newFlight;
            nextId++;
        }

        public void SearchFlights(List<KeyValuePair<int, Tuple<string, DateTime, DateTime, double, double>>> Trips)
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
                Console.Write("Unesite ID: ");
                var idInput = InputValid(Console.ReadLine(), Trips.Count());
                foreach (var trip in Trips)
                {
                    if (idInput == trip.Key)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                        "- Datum polaska: {3} - Datum dolaska: {4} " +
                        "- Vrijeme putovanja: {5} h \n",
                        trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4,
                        trip.Value.Item5);
                    }
                    else
                    { /// ovo u biti triba maknit jer ce onda printat za svaki let, stavit neki counter myb
                        Console.WriteLine("Nema letoa s unesenim ID-em. " +
                            "\nPritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                    }
                }
            }
            else if (input == 2)
            {
                Console.Write("Unesite naziv leta: ");
                var nameInput = NameValid(Console.ReadLine(), "name");
                foreach (var trip in Trips)
                {
                    if (nameInput == trip.Value.Item1)
                    {
                        Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                        "- Datum polaska: {3} - Datum dolaska: {4} " +
                        "- Vrijeme putovanja: {5} h \n",
                        trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4,
                        trip.Value.Item5);
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
            Console.Write("Uređivanje leta \n \nUnesite ID leta kojeg zelite urediti: ");
            var idInput = InputValid(Console.ReadLine(), Trips.Count()); //ispis ako uneseni id ne postoji ? 
            var confirm = Confirmation(idInput, "uređivanje");

            if (confirm == true)
            {
                Console.Write("Unesite novo vrijeme polaska: ");
                Trips[idInput].arrival = DateValid(Console.ReadLine());
                Console.Write("Unesite novo vrijeme dolaska: ");
                Trips[idInput].departure = DateValid(Console.ReadLine());
                //posada 

                //u biti nema smisla da se ranije printa jel uspjenso uredeno
                //al nez kako popravit bez da sve pastean ovdi
            }
        }

        public void DeleteFlight()
        {
            Console.Clear(); //honestly ovo i uredivanje bi mogla bit jedna fja. tj bar pola njihove funkcionalnosti
            Console.Write("Brisanje leta \n \nUnesite ID leta kojeg zelite izbrisati: ");
            var idInput = InputValid(Console.ReadLine(), Trips.Count()); //ispis ako uneseni id ne postoji ? 
            var confirm = Confirmation(idInput, "brisanje");

            if (confirm == true) 
            {
                Trips.Remove(idInput);
            }
        }

        public void ListFlights(List<KeyValuePair<int, Tuple<string, DateTime, DateTime, double, double>>> Trips)
        {
            foreach (var trip in Trips)
            {
                Console.WriteLine("ID: {0} - Naziv: {1} - Udaljenost: {2} km " +
                    "- Datum polaska: {3} - Datum dolaska: {4} " +
                    "- Vrijeme putovanja: {5} h \n",
                    trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4,
                    trip.Value.Item5);
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
    }
}
