namespace Aerodrom
{
    internal class Passengers : Funcionality
    {
        private int nextId = 2;
        public static Dictionary<int, User> Users { get; set; } = new Dictionary<int, User>();

        private User Registration() { 
        
            Console.Clear();
            Console.WriteLine("Registracija \n \n");

            string name = GetInput("Unesite ime: ", s => NameValid(s, "name"));
            string surname = GetInput("Unesite prezime: ", s=> NameValid(s, "surname"));
            DateTime dob = GetInput("Unesite datum rođenja: ", s=> DateValid(s));
            string email = GetInput("Unesite email adresu: ", s=> MailValid(s, Users));
            string password = GetInput("Unesite šifru: ", s => PswdValid(s));

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

        public void SearchFlights(int id)
        {
            var input = Menus.SearchMenu("Pretraživanje letova \n \n");
            if (Users[id].flights.Count() != 0)
            {
                if (input == 1) { SearchShow("ID", id); }
                else if (input == 2) { SearchShow("naziv", id); }
                else if (input == 0) { UserMenu(id); }
            }
            else 
            {
                Console.WriteLine("Korisnik nema zakazanih letova. \n");
                Continue(); 
                UserMenu(id); 
            }
        }

        private void SearchShow(string type, int id)
        {
            int idInput = -1;
            string nameInput = "0";

            if (type == "ID") { idInput = InputValid("Unesite ID", Flights.Trips.Count()); }
            else if (type == "naziv")
            {
                Console.Write("Unesite ime: ");
                nameInput = NameValid(Console.ReadLine(), "name");
            }

            foreach (var trip in Flights.Trips)
            {
                if (idInput == trip.Key && Users[id].flights.Contains(trip.Key)) 
                    { Flights.Print(trip); idInput = trip.Key; }
                if (nameInput == trip.Value.name && Users[id].flights.Contains(trip.Key)) 
                    { Flights.Print(trip); idInput = trip.Key; }
            }
            if (idInput == -1) { Console.WriteLine($"Nema letova s unesenim {type}om", type); }

            Continue();
            UserMenu(id);
        }

        public void CancelFlight(int id)
        {
            Menus.UserMenuLoggedIn(id, "Otkazivanje leta", Users);
            ListUserFlight(id);
            if (Users[id].flights.Count() != 0)
            {
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
            }
            else { Continue(); }
            UserMenu(id);
        }

        private void ListUserFlight(int id)
        {
            foreach (var flightId in Users[id].flights)
            {
                var trip = Flights.Trips.FirstOrDefault(t => t.Key == flightId);
                Flights.Print(trip);
            }
            if (Users[id].flights.Count() == 0) { Console.WriteLine("Korisnik nema zakazanih letova."); }
        }

        public void PassengersMenu()
        {
            int input = Menus.PassengersMenuInput();
            switch (input)
            {
                case 0: break;
                case 1: AddUser(); break;
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
                case 3: SearchFlights(id); break;
                case 4: CancelFlight(id); break;
            }
        }
    }
}
