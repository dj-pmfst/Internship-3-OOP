using static Aerodrom.Funcionality;
using static System.Net.Mime.MediaTypeNames;

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

        public static List<int> ID(int max)
        {
            List<int> idList = new List<int>();
            if (max != -1)
            {
                for (int index = 0; index <= max; index++) { idList.Add(index); }
            }
            return idList;
        }

        public static T GetInput<T>(string prompt, Func<string, T> validator)
        {
            while (true)
            {
                Console.Write("Unesite {0}",prompt);
                string input = Console.ReadLine();

                try { return validator(input); }
                catch (Exception ex) { Console.WriteLine($"Neispravan unos: {ex.Message}"); }
            }
        }

        public int idValid(string text, List<int> idList, string type)
        {
            Console.Write("{0}\nOdabir: ", text);
            var input = Console.ReadLine();
            if (type == "0")
            {
                while (!int.TryParse(input, out int id) || !idList.Contains(id)) { input = ErrInput(); }
            }
            else if (type == "search")
            {
                while (!int.TryParse(input, out int id)) { input = ErrInput(); }
                if (!idList.Contains(int.Parse(input))) { input = "-1"; }
            }
            return int.Parse(input);
        }
        public string PlaneValid(string name)
        {
            while (string.IsNullOrWhiteSpace(name) || name.Contains(" ")) { name = ErrInput(); }
            return name;
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

        public DateTime DateValidFlight(string dateInput)
        {
            while (!DateTime.TryParse(dateInput, out DateTime date) || date < DateTime.Now) { dateInput = ErrInput(); }
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
            while (string.IsNullOrWhiteSpace(name_input) || !name_input.All(Char.IsLetter) || name_input.Contains(" "))
            {
                Console.WriteLine("Neispravan unos. Unesite opet.");
                if (type == "name") { Console.Write("\nUnesite ime: "); }
                else if (type == "surname") { Console.Write("\nUnesite prezime: "); }
                name_input = Console.ReadLine();
            }
            name_input = char.ToUpper(name_input[0]) + name_input.Substring(1).ToLower();
            return name_input;
        }

        public static string MailValid(string mail, Dictionary<int, User> users)
        {
            bool exists = users.Any(u =>u.Value.email.Equals(mail, StringComparison.OrdinalIgnoreCase));

            while (string.IsNullOrWhiteSpace(mail) || !mail.Contains("@") || !mail.Contains(".") || exists == true || mail.Contains(" "))
            {
                if (exists == true) { Console.WriteLine("Korisnik s unesenim emailom već postoji."); }
                Console.WriteLine("Email mora sadržavati domenu (karakterizirano znakom @ i .)");
                Console.Write("Unesite opet: ");
                mail = Console.ReadLine();
                exists = users.Any(u => u.Value.email.Equals(mail, StringComparison.OrdinalIgnoreCase));
            }
            return mail;
        }

        public static string PswdValid(string pswd)
        {
            while (string.IsNullOrWhiteSpace(pswd) || pswd.Length < 4 || pswd.Contains(" "))
            {
                Console.WriteLine("Šifra ne može biti prazna ni kraća od 4 znaka.");
                Console.Write("Unesite šifru: ");
                pswd = Console.ReadLine();
            }
            return pswd;
        }


        public int CrewPick(Dictionary<int, CrewMember> CrewMembers, List<int> assignedCrew, string position)
        {
            List<int> valid = new List<int>();
            Console.WriteLine($"Dostupni {position}i: \n");
            foreach (var member in CrewMembers)
            {
                if (member.Value.position == position && !assignedCrew.Contains(member.Key))
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}",
                        member.Key, member.Value.name, member.Value.surname, member.Value.dob.ToString("dd/MM/yyyy"));
                        valid.Add(member.Key);
                }
            } 
            if (valid.Count > 0)
            {
                int id = InputValid($"\nUnesite ID {position}a kojeg želite dodati. ", CrewMembers.Count());
                if (valid.Contains(id)) { return id; }
                else { Console.WriteLine("Nema dostupnog {0}a s unesenim ID-om.", position); }
            }
            else { Console.WriteLine("\nNema dostupnih {0}a s unesenim ID-em.", position); }
            return -1;
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
