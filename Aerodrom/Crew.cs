namespace Aerodrom
{
    internal class Crew : Funcionality
    {
        private int nextId = 0;
        private int crewId = 0;
        public Dictionary<int, CrewMember> CrewMembers { get; set; } = new Dictionary<int, CrewMember>();

        public Dictionary<int, List<int>> crews = new Dictionary<int, List<int>>();

        public void AddCrew()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje posade \n \n");
            foreach (var member in CrewMembers)
            {
                if (member.Value.position == "pilot") 
                { 
                    Console.WriteLine("{0} - {1} - {2} - {3}", 
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob); 
                }
            }
            Console.Write("Unesite ID pilota kojeg želite dodati: ");
            var pilotId = InputValid(Console.ReadLine(), CrewMembers.Count()); //validacija da je uneseni id za pilota

            foreach (var member in CrewMembers)
            {
                if (member.Value.position == "copilot")
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob);
                }
            }
            Console.Write("Unesite ID kopilota kojeg želite dodati: "); //ovo bi se vjv moglo pojednostavnit
            var copilotId = InputValid(Console.ReadLine(), CrewMembers.Count());

            foreach (var member in CrewMembers)
            {
                if (member.Value.position == "steward" || member.Value.position == "stewardess")    
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob);
                }
            }
            Console.Write("Unesite ID stujara/ese kojeg/u želite dodati: ");
            var stewradId = InputValid(Console.ReadLine(), CrewMembers.Count());

            crews[nextId] = new List<int> { pilotId, copilotId, stewradId };
            nextId++;

            //treba dodat provjeru da uneseni clan nije vec negdi
        }

        public CrewMember CrewMemberRegistration()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje člana posade \n \n");
            Console.Write("Unesite ime: ");
            var name = NameValid(Console.ReadLine(), "name");
            Console.Write("Unesite prezime: ");
            var surname = NameValid(Console.ReadLine(), "surname");
            Console.Write("Unesite datum rođenja: ");
            DateTime dob = DateValid(Console.ReadLine());
            Console.Write("Unesite spol (male/female): ");
            var gender = GenderValid(Console.ReadLine());
            Console.Write("Unesite poziciju: ");
            var position = PositionValid(Console.ReadLine());

            Console.WriteLine("Uspješno registriran član posade {0} {1}", name, surname);

            return new CrewMember
            {
                id = nextId,
                name = name,
                surname = surname,
                dob = dob,
                position = position,
                gender = gender  
            };
        }

        public void AddCrewMember()
        {
            var newCrewMember = CrewMemberRegistration();
            CrewMembers[nextId] = newCrewMember;
            nextId++;
        }

        public void ListCrew()
        {
            Console.Clear();
            Console.WriteLine("Prikaz svih posada");
            foreach (var item in crews)
            {
                Console.WriteLine("\nPosada {0}", item.Key);
                foreach (var id in item)
                {
                    Console.WriteLine(" {0} - {1} - {2} - {3}",
                        CrewMembers[id].Key, CrewMembers[id].Value.name, CrewMembers[id].Value.surname, CrewMembers.Value.position);
                }
            }
        }

        public static int CrewMenuInput()
        {
            Console.Clear();
            Console.Write("Posada \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih posada \n 2-Kreiranje nove posade " +
                "\n 3-Dodavanje osobe \n 0-Povratak na prethodni izbornik";

            var firstInput = InputValid(menuText, 3);

            return firstInput;
        }
    }
}
