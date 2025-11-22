namespace Aerodrom
{
    internal class Crew : Funcionality
    {
        private List<int> memberId = ID(8);
        public static List<int> crewId = ID(2);
        public Dictionary<int, CrewMember> CrewMembers { get; set; } = new Dictionary<int, CrewMember>();

        public Dictionary<int, List<int>> Crews = new Dictionary<int, List<int>>();
        public List<int> assignedCrew { get; set; } = new List<int> {0,1,2,3,4,5,6,7,8};

        public void AddCrew()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje posade \n \n");

            int pilotId = CrewPick(CrewMembers, assignedCrew, "pilot");
            int copilotId = CrewPick(CrewMembers, assignedCrew, "copilot");
            int stewardId = CrewPick(CrewMembers, assignedCrew, "attendant");

            List<int> invalid = new List<int>() { pilotId, copilotId, stewardId};

            if (invalid.Contains(-1))
            {
                Console.WriteLine("\nNemoguće formirat posadu zbog manjka dostupnih članova posade.");
            }
            else
            {
                var nextId = crewId.LastOrDefault()+1;
                Crews[nextId] = new List<int> { pilotId, copilotId, stewardId };
                assignedCrew.Add(pilotId);
                assignedCrew.Add(copilotId);
                assignedCrew.Add(stewardId);
                crewId.Add(nextId);
                Console.WriteLine("Uspješno dodana posada.");
            }
            Continue();
            CrewMenu(); ;
        }

        private CrewMember CrewMemberRegistration()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje člana posade \n \n");

            string name = GetInput("ime: ", s => NameValid(s, "name"));
            string surname = GetInput("prezime: ", s => NameValid(s, "surname"));
            DateTime dob = GetInput("datum rođenja: ", s => DateValid(s));
            var gender = GetInput("spol (m/f): ", s=> GenderValid(s));
            var position = GetInput("poziciju (pilot/copilot/attendant): ", s=> PositionValid(s));

            Console.WriteLine("Uspješno registriran član posade {0} {1}", name, surname);

            return new CrewMember(name, surname, dob, position, gender);
        }

        public void AddCrewMember()
        {
            var newCrewMember = CrewMemberRegistration();
            var nextId = memberId.LastOrDefault()+1;
            CrewMembers[nextId] = newCrewMember;
            memberId.Add(nextId);

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
