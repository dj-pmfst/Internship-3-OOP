namespace Aerodrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Planes planes = new Planes();

            Crew crewInstance = new Crew();
            Flights flights = new Flights(crewInstance);

            Passengers passengers = new Passengers();  
            Crew crew = new Crew(); 

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

            while (inApp)   
            //rearangeat da su svi menuinput i sl inputi za druge fje u zasebnoj klasi.
            //u usermenu i sl stavit enum
            {
                Console.Clear();
                var menuInput = MainMenu();
                if (menuInput == 1)
                {
                    input = Passengers.PassengersMenuInput();
                    passengers.PassengersMenu(input);
                }
                else if (menuInput == 2)
                {
                    input = Flights.FlightsMenuInput();
                    flights.FlightsMenu(input);
                }
                else if (menuInput == 3)
                {
                    input = Planes.PlanesMenuInput();
                    planes.PlanesMenu(input);
                }
                else if (menuInput == 4)
                {
                    input = Crew.CrewMenuInput();
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