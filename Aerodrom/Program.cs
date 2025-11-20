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

            static int MainMenu()
            {
                Console.Write("Glavni izbornik \n \n ");
                var menuText = "Unesite broj za željenu opciju " +
                    "\n 1-Putnici \n 2-Letovi \n 3-Avioni \n 4-Posada" +
                    "\n 0-Izlaz iz aplikacije";

                var firstInput = Funcionality.InputValid(menuText, 4);

                return firstInput;
            }

            bool inApp = true;
            int input;

            passengers.Users.Add(0, new User("Ana", "Anic", DateTime.Parse("3.3.1990"), "anaanic@mail.com", "1234"));
            passengers.Users.Add(1, new User("Mate", "Matic", DateTime.Parse("3.3.1995"), "matematic@mail.com", "4321"));

            flights.Trips.Add(0, new Flight("Pariz", DateTime.Parse("5.5.2025."), DateTime.Parse("5.5.2025."), 457, 2, 0));
            flights.Trips.Add(1, new Flight("New York", DateTime.Parse("21.5.2025."), DateTime.Parse("22.5.2025."), 1102, 17, 1));
            flights.Trips.Add(2, new Flight("Peking", DateTime.Parse("5.2.2025."), DateTime.Parse("6.2.2025."), 1365, 22, 2));

            crew.CrewMembers.Add(0, new CrewMember("Maria", "Maric", DateTime.Parse("9.7.2002."), "stewardess", "female"));
            crew.CrewMembers.Add(1, new CrewMember("Marko", "Markic", DateTime.Parse("9.10.2000."), "steward", "male"));
            crew.CrewMembers.Add(2, new CrewMember("Ivo", "Ivic", DateTime.Parse("19.8.1985."), "copilot", "male"));
            crew.CrewMembers.Add(3, new CrewMember("Lucija", "Lucic", DateTime.Parse("21.10.2002."), "pilot", "female"));


            planes.Airplanes.Add(0, new Plane("a320", 2012, 1, seats));
            planes.Airplanes.Add(1, new Plane("a350", 2005, 1, seats));
            planes.Airplanes.Add(2, new Plane("a380", 2010, 1, seats));

            crew.Crews.Add(0, new List<int> { 3,2,0 });
            crew.Crews.Add(1, new List<int> { 1 });
            crew.Crews.Add(2, new List<int> {  });


            while (inApp)   
            //rearangeat da su svi menuinput i sl inputi za druge fje u zasebnoj klasi.
            //u usermenu i sl stavit enum
            {
                Console.Clear();
                var menuInput = MainMenu();
                if (menuInput == 1)
                {
                    input = Menus.PassengersMenuInput();
                    passengers.PassengersMenu(input);
                }
                else if (menuInput == 2)
                {
                    input = Menus.FlightsMenuInput();
                    flights.FlightsMenu(input);
                }
                else if (menuInput == 3)
                {
                    input = Menus.PlanesMenuInput();
                    planes.PlanesMenu(input);
                }
                else if (menuInput == 4)
                {
                    input = Menus.CrewMenuInput();
                    crew.CrewMenu(input);
                }
                else if (menuInput == 0)
                {
                    Console.WriteLine("Izlazak iz aplikacije.");
                    inApp = false;
                }
            }
            
        }
    }
}