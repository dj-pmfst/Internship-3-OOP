namespace Aerodrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            {
                Console.Clear();
                var menuInput = MainMenu();
                if (menuInput == 1)
                {
                    input = Passengers.PassengersMenuInput();
                }
                else if (menuInput == 2)
                {
                    input = Flights.FlightsMenuInput();
                }
                else if (menuInput == 3)
                {
                    input = Planes.PlanesMenuInput();
                }
                else if (menuInput == 4)
                {
                    input = Crew.CrewMenuInput();
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