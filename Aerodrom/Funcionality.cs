using static Aerodrom.Funcionality;

namespace Aerodrom
{
    internal class Funcionality
    {
        public enum Gender
        {
            male,
            female,
            m,
            f
        }
        public enum Position
        {
            pilot,
            copilot,
            attendant
        }

        public string GenderValid(string genderInput)
        {
            while(!Enum.TryParse(genderInput.ToLower(), true, out Gender gender)) { genderInput = ErrInput(); }
            return genderInput;
        }

        public string PositionValid(string positionInput)
        {
            while (!Enum.TryParse(positionInput.ToLower(), true, out Position position)) { positionInput = ErrInput(); }
            return positionInput;
        }

        public DateTime DateValid(string dateInput)
        {
            while (!DateTime.TryParse(dateInput, out DateTime date) || date.Year > 2025) { dateInput = ErrInput(); }
            return DateTime.Parse(dateInput);
        }

        public double NumberValid(string numberInput)
        {
            while (!double.TryParse(numberInput, out double number) || double.Parse(numberInput) < 0) { numberInput = ErrInput(); }
            return double.Parse(numberInput);
        }

        public static int InputValid(string text, int count)
        {
            if (text == "0") { Console.Write("\n\nOdabir: "); }
            else { Console.Write("{0}\n\nOdabir: ", text); }

            var input_input = Console.ReadLine();

            while (!int.TryParse(input_input, out int number) || int.Parse(input_input) > count || int.Parse(input_input) < 0)
            {
                Console.Write("\nNeispravan unos. Unesite opet.");

                if (text == "0") { Console.Write("\nOdabir: "); }
                else { Console.Write("\n {0}\nOdabir: ", text); }

                input_input = Console.ReadLine();
            }
            return int.Parse(input_input);
        }

        public string NameValid(string name_input, string type)
        {
            while (string.IsNullOrWhiteSpace(name_input) || !name_input.All(Char.IsLetter))
            {
                Console.WriteLine("Neispravan unos. Unesite opet.");
                if (type == "name") { Console.Write("\nUnesite ime: "); }
                else if (type == "surname") { Console.Write("\nUnesite prezime: "); }
                name_input = Console.ReadLine();
            }
            name_input = char.ToUpper(name_input[0]) + name_input.Substring(1).ToLower();
            return name_input;
        }

        public int CrewPick(Dictionary<int, CrewMember> CrewMembers, List<int> assignedCrew, string position)
        {
            Console.WriteLine("Dostupni {position}i:");
            foreach (var member in CrewMembers)
            {
                if (member.Value.position == position && !assignedCrew.Contains(member.Key))
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob.ToString());
                }
            }
            int id = InputValid($"Unesite ID {position}a kojeg želite dodati. ", CrewMembers.Count());
            return id;
        }

        public bool Confirmation(int id, string type)
        {
            Console.Write("\nJeste li sigurni da želite izmjeniti {0}? (y/n): ", id); 
            var message = Console.ReadLine();
            if (message.ToLower() == "y" || message.ToLower() == "yes" || message.ToLower() == "da")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Otkazano {0}", type);
                Continue();
                return false;
            }
        }

        public void Continue()
        {
            Console.WriteLine("\nPritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public string ErrInput()
        {
            Console.Write("\nNeispravan unos. \nUnesite opet:");
            return Console.ReadLine();
        }
    }
}
