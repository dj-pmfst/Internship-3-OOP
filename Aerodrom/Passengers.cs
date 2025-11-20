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

            return new User(name, surname, dob, email, password);
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

        public void PassengersMenu(int input)
        {
            switch (input)
            {
                case 0: break;
                case 1: Registration(); break;
                case 2: LogIn(); break;
            }
        }

        public void UserMenu(int input)
        {
            switch (input)
            {
                case 0: Menus.PassengersMenuInput(); break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
            }
        }
    }
}
