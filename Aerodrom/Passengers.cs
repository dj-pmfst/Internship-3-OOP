namespace Aerodrom
{
    internal class Passengers : Funcionality
    {
        private int nextId = 2;
        public Dictionary<int, User> Users { get; set; } = new Dictionary<int, User>();

        public User Registration() { 
        
            Console.Clear();
            Console.WriteLine("Registracija \n \n");
            Console.Write("Unesite ime: ");
            string name = NameValid(Console.ReadLine(), "name");
            Console.Write("Unesite prezime: ");
            string surname = NameValid(Console.ReadLine(), "surname");
            Console.Write("Unesite datum rođenja: ");
            DateTime dob = DateValid(Console.ReadLine());
            Console.Write("Unesite email adresu: ");
            string email = Console.ReadLine();
            Console.Write("Unesite šifru: ");
            string password = Console.ReadLine();

            Console.WriteLine("Uspješno registriran korisnik {0} {1}", name, surname);

            return new User(name, surname, dob, email, password, new List<int>());
        }

        public void AddUser()
        {
            var newUser = Registration();
            Users[nextId] = newUser;
            nextId++;
            Continue();
            PassengersMenu();
        }

        public void LogIn()
        {
            bool login = false;
            int id;
            Console.Clear();
            Console.WriteLine("Prijava \n");
            Console.Write("Unesite email: ");
            string emailInput = Console.ReadLine();
            Console.Write("Unesite šifru: ");
            string passwordInput = Console.ReadLine();

            foreach (var user in Users)
            {
                if (user.Value.email == emailInput && user.Value.password == passwordInput) 
                {                    
                    login = true;
                    id = user.Key;
                    UserMenu(id); 
                }
            }
            if (login == false)
            {
                Console.WriteLine("Neuspješna prijava.");
                Continue();
                PassengersMenu();
            }
        }

        public void UserFlights(int id)
        {
            Menus.UserMenuLoggedIn(id, "Prikaz svih zakazanih letova", Users);
            ListUserFlight(id);
            Continue();
            UserMenu(id);
        }

        public void ChooseFlight(int id)
        {
            Menus.UserMenuLoggedIn(id, "Odabir leta", Users);
            foreach (var flight in Flights.Trips) 
            {
                if (!Users[id].flights.Contains(flight.Key)) { Flights.Print(flight); } 
            }

            Console.Write("Unesite ID leta koji želite zakazati.");
            var flightId = InputValid("0", Flights.Trips.Count());
            if (!Users[id].flights.Contains(flightId))
            {
                Users[id].flights.Add(flightId);
                Console.WriteLine("Uspjesno dodan let {0}", flightId);
            }
            else { Console.WriteLine("Korisnik je već zakazao taj let."); }
            Continue();
            UserMenu(id);
        }

        public void CancelFlight(int id)
        {
            Menus.UserMenuLoggedIn(id, "Otkazivanje leta", Users);
            ListUserFlight(id);

            Console.Write("Unesite ID leta kojeg želite otkazati.");
            var inputId = InputValid("0", Flights.Trips.Count());

            var flightDate = Flights.Trips.FirstOrDefault(t => t.Key == inputId).Value.departure;
            var timeLeft = flightDate - DateTime.Now;

            if (timeLeft < new TimeSpan(0,24,0,0,0)) 
            { 
                Console.WriteLine("Let {0} je za manje od 24h, ne može se otkazati.", inputId); 
                Continue(); 
            }
            else if (timeLeft > new TimeSpan(0,24,0,0)) 
            {
                var confirm = Confirmation(inputId, "brisanje");
                if (confirm == true) { Users[id].flights.Remove(inputId); } 
            }
            UserMenu(id);
        }

        private void ListUserFlight(int id)
        {
            foreach (var flightId in Users[id].flights)
            {
                var trip = Flights.Trips.FirstOrDefault(t => t.Key == flightId);
                Flights.Print(trip);
            }
        }

        public void PassengersMenu()
        {
            int input = Menus.PassengersMenuInput();
            switch (input)
            {
                case 0: break;
                case 1: Registration(); break;
                case 2: LogIn(); break;
            }
        }

        public void UserMenu(int id)
        {
            int input = Menus.UserMenuInput(id, Users);
            switch (input)
            {
                case 0: Menus.PassengersMenuInput(); break;
                case 1: UserFlights(id);  break;
                case 2: ChooseFlight(id); break;
                case 3: break;
                case 4: CancelFlight(id); break;
            }
        }
    }
}
