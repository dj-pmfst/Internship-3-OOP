namespace Aerodrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Passengers passengers = new Passengers();
            Planes planes = new Planes();
            Crew crew = new Crew();
            Flights flights = new Flights(crew);


            bool inApp = true;
            int input;

            passengers.Users.Add(0, new User("Ana", "Anic", DateTime.Parse("3.3.1990"), "anaanic@mail.com", "1234", new List<int>()));
            passengers.Users.Add(1, new User("Mate", "Matic", DateTime.Parse("3.3.1995"), "matematic@mail.com", "4321", new List<int>()));

            Flights.Trips.Add(0, new Flight("Pariz", DateTime.Parse("5.5.2025. 12:00"), DateTime.Parse("5.5.2025. 14:00"), 457, 2, 0));
            Flights.Trips.Add(1, new Flight("Chicago", DateTime.Parse("21.12.2025. 20:00"), DateTime.Parse("22.12.2025. 13:00"), 1102, 17, 1));
            Flights.Trips.Add(2, new Flight("Peking", DateTime.Parse("5.2.2025. 8:00"), DateTime.Parse("6.2.2025. 6:00"), 1365, 22, 2));

            crew.CrewMembers.Add(0, new CrewMember("Maria", "Maric", DateTime.Parse("9.7.2002."), "attendant", "female"));
            crew.CrewMembers.Add(1, new CrewMember("Marko", "Markic", DateTime.Parse("9.10.2000."), "attendant", "male"));
            crew.CrewMembers.Add(2, new CrewMember("Ivo", "Ivic", DateTime.Parse("19.8.1985."), "copilot", "male"));
            crew.CrewMembers.Add(3, new CrewMember("Lucija", "Lucic", DateTime.Parse("21.10.2002."), "pilot", "female"));

            crew.CrewMembers.Add(4, new CrewMember("Tomislav", "Tomic", DateTime.Parse("12.12.1988."), "pilot", "male"));
            crew.CrewMembers.Add(5, new CrewMember("Evan", "Evic", DateTime.Parse("7.7.1995."), "attendant", "male"));
            crew.CrewMembers.Add(6, new CrewMember("Ivan", "Ivic", DateTime.Parse("23.11.1983."), "copilot", "male"));

            crew.CrewMembers.Add(7, new CrewMember("Marina", "Marincic", DateTime.Parse("2.2.1992."), "pilot", "female"));
            crew.CrewMembers.Add(8, new CrewMember("Petar", "Petrovic", DateTime.Parse("14.6.1987."), "copilot", "male"));


            var seats = new List<Tuple<string, int>>();

            seats = new List<Tuple<string, int>>() { Tuple.Create("economy", 100), Tuple.Create("business", 40) };
            planes.Airplanes.Add(0, new Plane("a320", 2010, 1, seats));
            seats = new List<Tuple<string, int>>() { Tuple.Create("economy", 300), Tuple.Create("business", 50) };
            planes.Airplanes.Add(1, new Plane("a350", 2005, 1, seats));
            seats = new List<Tuple<string, int>>() { Tuple.Create("economy", 400), Tuple.Create("business", 120) };
            planes.Airplanes.Add(2, new Plane("a380", 2012, 1, seats));

            crew.Crews.Add(0, new List<int> { 3,2,0 });
            crew.Crews.Add(1, new List<int> { 4,6,1});
            crew.Crews.Add(2, new List<int> { 7,8,5 });


            while (inApp)   
            {
                Console.Clear();
                var menuInput = Menus.MainMenu();
                if (menuInput == 1) { passengers.PassengersMenu(); }
                else if (menuInput == 2) { flights.FlightsMenu(); }
                else if (menuInput == 3) { planes.PlanesMenu(); }
                else if (menuInput == 4) { crew.CrewMenu(); }
                else if (menuInput == 0)
                {
                    Console.WriteLine("Izlazak iz aplikacije.");
                    inApp = false;
                }
            }   
        }
    }
}