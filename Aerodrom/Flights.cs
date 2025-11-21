using System.Collections.Generic;
using System.Numerics;

namespace Aerodrom
{
    internal class Flights : Funcionality
    {
        private int nextId = 3;

        private Crew crew;
        public Dictionary<int, Flight> Trips { get; set; } = new Dictionary<int, Flight>();
        public Flights(Crew c) { crew = c; }

        public Flight RegisterFlight()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje letova \n \n");
            Console.Write("Unesite ime: ");
            string name = NameValid(Console.ReadLine(), "name");
            Console.Write("Unesite datum i vrijeme polaska: ");
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
            var input = Menus.SearchMenu("Pretraživanje letova \n \n");

            if (input == 1) { SearchShow("ID"); }
            else if (input == 2) { SearchShow("naziv"); }
            else if (input == 0) { Menus.FlightsMenuInput(); }
        }

        private void SearchShow(string type)
        {
            int idInput = -1;
            string nameInput = "0";
            if (type == "ID") { idInput = InputValid("Unesite ID", Trips.Count()); }
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
            Menus.FlightsMenuInput();
        }

        public void EditFlight()
        {
            Console.Clear(); 
            Console.WriteLine("Uređivanje leta \n \n");
            foreach (var flight in Trips) { Print(flight); }

            var idInput = InputValid("\nUnesite ID leta kojeg zelite urediti. ", Trips.Count()); //ispis ako uneseni id ne postoji ? nema potrebe ako listan sve prije
            var confirm = Confirmation(idInput, "uređivanje");

            if (confirm == true)
            {
                Console.Write("Unesite novo vrijeme polaska: ");
                Trips[idInput].arrival = DateValid(Console.ReadLine());
                Console.Write("Unesite novo vrijeme dolaska: ");
                Trips[idInput].departure = DateValid(Console.ReadLine());
                Trips[idInput].crewId = InputValid("Unesite ID nove posade. ", crew.Crews.Count);

                Console.WriteLine("Uspješno uređivanje.");
                Continue();
            }
        }
        
        public void DeleteFlight()
        {
            Console.Clear();
            Console.WriteLine("Brisanje leta \n \n");
            foreach (var flight in Trips) { Print(flight); }

            var idInput = InputValid("\nUnesite ID leta kojeg zelite izbrisati: ", Trips.Count());  
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
            Menus.FlightsMenuInput();
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
            }
        }

        public void Print(KeyValuePair<int,Flight> trip)
        {
            Console.WriteLine("\nID: {0} - Naziv: {1} - Udaljenost: {2} km " +
            "- Datum polaska: {3} - Datum dolaska: {4} " +
            "- Vrijeme putovanja: {5} h \n",
            trip.Key, trip.Value.name, trip.Value.distance, trip.Value.arrival, trip.Value.departure,
            trip.Value.duration);
        }
    }
}
