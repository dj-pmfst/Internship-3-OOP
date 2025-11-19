namespace Aerodrom
{
    internal class Flights : Funcionality
    {
        public int id;
        public string name;
        public DateTime departure;
        public DateTime arrival;
        public double distance;
        public double duration;

        public void AddFlight()
        {

        }

        public void SearchFlights()
        {

        }

        public void EditFlight(int id)
        {

        }

        public void DeleteFlight(int id)
        {

        }

        public void ListFlights(List<KeyValuePair<int, Tuple<string, double, double, double, double>>> user_trips)
        {
            foreach (var trip in user_trips)
            {
                Console.WriteLine("ID: {0} \nNaziv: {1} \nUdaljenost: {2} km " +
                    "\nDatum polaska: {3}  \nDatum dolaska: {4} " +
                    "\nVrijeme putovanja: {5} h \n",
                    trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4,
                    Math.Round(trip.Value.Item5, 2));
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
