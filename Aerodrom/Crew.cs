namespace Aerodrom
{
    internal class Crew : Funcionality
    {
        private int nextId = 9;
        private int crewId = 3;
        public Dictionary<int, CrewMember> CrewMembers { get; set; } = new Dictionary<int, CrewMember>();

        public Dictionary<int, List<int>> Crews = new Dictionary<int, List<int>>();
        public List<int> assignedCrew { get; set; } = new List<int> {0,1,2,3,4,5,6,7,8};

        public void AddCrew()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje posade \n \n");
            //validacija da je uneseni id za pilota
            int pilotId = CrewPick(CrewMembers, assignedCrew, "pilot");
            int copilotId = CrewPick(CrewMembers, assignedCrew, "copilot");
            int stewardId = CrewPick(CrewMembers, assignedCrew, "attendant");

            Crews[crewId] = new List<int> { pilotId, copilotId, stewardId };
            assignedCrew.Add(pilotId);
            assignedCrew.Add(copilotId);
            assignedCrew.Add(stewardId);
            crewId++;

            Console.WriteLine("Uspješno dodana posada.");
            Continue();
            CrewMenu(); ;
        }

        private CrewMember CrewMemberRegistration()
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

            return new CrewMember(name, surname, dob, position, gender);
        }

        public void AddCrewMember()
        {
            var newCrewMember = CrewMemberRegistration();
            CrewMembers[nextId] = newCrewMember;
            nextId++;

            Continue();
            CrewMenu();
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
            Continue();
            CrewMenu();
        }

        public void CrewMenu()
        {
            int input = Menus.CrewMenuInput();
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
