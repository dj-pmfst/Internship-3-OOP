namespace Aerodrom
{
    internal class Crew : Funcionality
    {
        private int nextId = 0;
        private int crewId = 0;
        public Dictionary<int, CrewMember> CrewMembers { get; set; } = new Dictionary<int, CrewMember>();

        public Dictionary<int, List<int>> Crews = new Dictionary<int, List<int>>();

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
            var pilotId = InputValid("Unesite ID pilota kojeg želite dodati: ", CrewMembers.Count()); //validacija da je uneseni id za pilota

            foreach (var member in CrewMembers)
            {
                if (member.Value.position == "copilot")
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob);
                }
            }
            //ovo bi se vjv moglo pojednostavnit
            var copilotId = InputValid("Unesite ID kopilota kojeg želite dodati: ", CrewMembers.Count());

            foreach (var member in CrewMembers)
            {
                if (member.Value.position == "steward" || member.Value.position == "stewardess")    
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob);
                }
            }
            var stewradId = InputValid("Unesite ID stujara/ese kojeg/u želite dodati: ", CrewMembers.Count());

            Crews[crewId] = new List<int> { pilotId, copilotId, stewradId };
            crewId++;

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
            foreach (var item in Crews)
            {
                Console.WriteLine("\nPosada {0}", item.Key);
                foreach (var id in item.Value)
                {
                    Console.WriteLine(" {0} - {1} - {2} - {3}",
                        id, CrewMembers[id].name, CrewMembers[id].surname, CrewMembers[id].position);
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
        public void CrewMenu(int input)
        {
            switch (input)
            {
                case 0: break;
                case 1: ListCrew(); break;
                case 2: AddCrew(); break;
                case 3: AddCrewMember(); break;
            }
        }
    }
}
