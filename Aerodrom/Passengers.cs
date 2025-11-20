namespace Aerodrom
{
    internal class Passengers : Funcionality
    {
        private int nextId = 0;
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

            return new User
            {
                id = nextId,
                name = name,
                surname = surname,
                dob = dob,
                email = email,
                password = password
            };
        }

        public void AddUser()
        {
            var newUser = Registration();
            Users[nextId] = newUser;
            nextId++;
        }

        public void LogIn()
        {
            Console.Clear();
            Console.WriteLine("Prijava \n \n");
            Console.Write("Unesite email: ");
            Console.Write("Unesite šifru: ");
        }

        public static int PassengersMenuInput()
        {
            Console.Clear();
            Console.Write("Putnici \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Registracija \n 2-Prijava " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 2);
            return input;
        }

        public static int UserMenuInput()
        {
            Console.Clear();
            Console.Write("Prijava \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih letova \n 2-Odabir leta " +
                "\n 3-Pretraživanje letova \n 4-Otkazivanje leta " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 4);
            return input;
        }
        public void PassengersMenu(int input)
        {
            switch (input)
            {
                case 0: break;
                case 1: Registration(); break;
                case 2: LogIn(); break;
            }
        }
    }
}
