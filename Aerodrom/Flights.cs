using System.Collections.Generic;
using System.Numerics;

namespace Aerodrom
{
    internal class Flights : Funcionality
    {
        private int nextId = 3;

        private Crew crew;
        public static Dictionary<int, Flight> Trips { get; set; } = new Dictionary<int, Flight>();
        public Flights(Crew c) { crew = c; }

        public Flight RegisterFlight()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje letova \n \n");

            string name = GetInput("ime: ", s => NameValid(s, "name"));
            DateTime departure = GetInput("datum i vrijeme polaska (ne smije biti prije današnjeg datuma): ", s=> DateValidFlight(s));
            DateTime arrival = GetInput("datum i vrijeme dolaska: ", s=> DateValidFlight(s));
            double distance = GetInput("udaljenost: ", s=> NumberValid(s));
            int crewId = InputValid("Unesite ID posade. ", crew.Crews.Count);
            int planeId = InputValid("Unesite ID aviona.", Planes.Airplanes.Count);

            Planes.Airplanes[planeId].flights.Add(nextId);
            TimeSpan duration = arrival - departure;

            Console.WriteLine("Uspješno registriran let {0}", name);

            return new Flight(name, departure, arrival, distance, duration.TotalHours , crewId);
        }

        public void AddFlight()
        {
            var newFlight = RegisterFlight();
            Trips[nextId] = newFlight;
            nextId++;
            Continue();
            FlightsMenu();
        }

        public void SearchFlights()
        {
            var input = Menus.SearchMenu("Pretraživanje letova \n \n");

            if (input == 1) { SearchShow("ID"); }
            else if (input == 2) { SearchShow("naziv"); }
            else if (input == 0) { FlightsMenu(); }
        }

        private void SearchShow(string type)
        {
            int idInput = -1;
            string nameInput = "0";
            if (type == "ID") { idInput = InputValid("Unesite ID", nextId); }
            else if (type == "naziv") 
            { 
                Console.Write("Unesite ime: "); 
                nameInput = NameValid(Console.ReadLine(), "name"); 
            }
            foreach (var trip in Trips)
            {
                if (idInput == trip.Key) { Print(trip); idInput = trip.Key; }
                if (nameInput == trip.Value.name) { Print(trip); idInput = trip.Key; }
            }
            if (idInput == -1) { Console.WriteLine($"Nema letova s unesenim {type}om", type); }
            Continue();
            FlightsMenu();
        }

        public void EditFlight()
        {
            Console.Clear(); 
            Console.WriteLine("Uređivanje leta \n \n");
            foreach (var flight in Trips) { Print(flight); }

            var idInput = InputValid("\nUnesite ID leta kojeg zelite urediti. ", nextId); 
            var confirm = Confirmation(idInput, "uređivanje");

            if (confirm == true)
            {
                Console.Write("Unesite novo vrijeme polaska: ");
                Trips[idInput].arrival = DateValidFlight(Console.ReadLine());
                Console.Write("Unesite novo vrijeme dolaska: ");
                Trips[idInput].departure = DateValidFlight(Console.ReadLine());
                Trips[idInput].crewId = InputValid("Unesite ID nove posade. ", crew.Crews.Count);

                Console.WriteLine("Uspješno uređivanje.");
                Continue();
            }
            FlightsMenu();
        }
        
        public void DeleteFlight()
        {
            Console.Clear();
            Console.WriteLine("Brisanje leta \n \n");

            if (Trips.Count != 0)
            {
                foreach (var flight in Trips) { Print(flight); }

                var idInput = InputValid("\nUnesite ID leta kojeg zelite izbrisati: ", Trips.Count());
                var timeLeft = Trips[idInput].departure - DateTime.Now;
                if (timeLeft < new TimeSpan(0, 24, 0, 0, 0))
                {
                    Console.WriteLine("Let {0} je za manje od 24h, ne može se otkazati.", idInput);
                }
                else if (timeLeft > new TimeSpan(0, 24, 0, 0))
                {
                    var confirm = Confirmation(idInput, "brisanje");
                    if (confirm == true) 
                    { 
                        Trips.Remove(idInput);
                        foreach (var user in Passengers.Users)
                        {
                            if (user.Value.flights.Contains(idInput))
                            {
                                user.Value.flights.Remove(idInput);
                            }
                        }
                        foreach (var plane in Planes.Airplanes)
                        {
                            if (plane.Value.flights.Contains(idInput))
                            {
                                plane.Value.flights.Remove(idInput);
                            }
                        }
                    }
                }
            }
            else { Console.WriteLine("Nema zakazanih letova."); }

            Continue();
            FlightsMenu();
        }
        private void SortByAlphabet()
        {
            Console.Clear();
            Console.WriteLine("Ispis svih letova abecedno \n \n");
            var sortedFlights = Flights.Trips.ToList();
            sortedFlights.Sort((a, b) => string.Compare(a.Value.name, b.Value.name, StringComparison.OrdinalIgnoreCase));
            foreach (var trip in sortedFlights) { Print(trip); }
            Continue();
            SortFlights();
        }
        private void SortByTime(string type)
        {
            Console.Clear();
            List<KeyValuePair<int, Flight>> sortedFlights = new List<KeyValuePair<int, Flight>>();

            if (type == "up")
            {
                Console.WriteLine("Ispis svih letova prema vremenu polaska uzlazno \n \n");
                sortedFlights = Trips.OrderBy(p => p.Value.departure).ToList();
            }
            else if (type == "down")
            {
                Console.WriteLine("Ispis svih letova prema vremenu polaska silazno \n \n");
                sortedFlights = Trips.OrderByDescending(p => p.Value.departure).ToList();
            }
            foreach (var trip in sortedFlights) { Print(trip); }
            Continue();
            SortFlights();
        }

        private void SortByDuration(string type)
        {
            Console.Clear();
            List<KeyValuePair<int, Flight>> sortedFlights = new List<KeyValuePair<int, Flight>>();

            if (type == "up")
            {
                Console.WriteLine("Ispis svih letova prema trajanju uzlazno \n \n");
                sortedFlights = Trips.OrderBy(p => p.Value.duration).ToList();
            }
            else if (type == "down")
            {
                Console.WriteLine("Ispis svih letova prema trajanju silazno \n \n");
                sortedFlights = Trips.OrderByDescending(p => p.Value.duration).ToList();
            }
            foreach (var trip in sortedFlights) { Print(trip); }
            Continue();
            SortFlights();
        }

        public void ListFlights()
        {
            if (Trips.Count != 0)
            {
                foreach (var trip in Trips) { Print(trip); }
            }
            else { Console.WriteLine("Nema zakazanih letova."); }
            Continue();
            FlightsMenu();
        }

        public void FlightsMenu()
        {
            int input = Menus.FlightsMenuInput();
            switch (input)
            {
                case 0: break;
                case 1: ListFlights(); break;
                case 2: AddFlight(); break;
                case 3: SearchFlights(); break;
                case 4: EditFlight(); break;
                case 5: DeleteFlight(); break;
                case 6: SortFlights(); break;
            }
        }
        private void SortFlights()
        {
            int input = Menus.SortFlightsInput();
            switch (input)
            {
                case 0: FlightsMenu(); break;
                case 1: SortByAlphabet(); break;
                case 2: SortByTime("up"); break;
                case 3: SortByTime("down"); break;
                case 4: SortByDuration("up"); break;
                case 5: SortByDuration("down"); break;
            }
        }

        public static void Print(KeyValuePair<int,Flight> trip)
        {
            Console.WriteLine("\nID: {0} - Naziv: {1} - Udaljenost: {2} km " +
            "- Datum polaska: {3} - Datum dolaska: {4} " +
            "- Vrijeme putovanja: {5} h \n",
            trip.Key, trip.Value.name, trip.Value.distance, trip.Value.departure, trip.Value.arrival,
            Math.Round(trip.Value.duration,2));
        }
    }
}
