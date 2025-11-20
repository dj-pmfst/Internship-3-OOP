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
            steward,
            stewardess
        }

        public static string GenderValid(string genderInput)
        {
            while(!Enum.TryParse(genderInput.ToLower(), true, out Gender gender)) { genderInput = ErrInput(); }
            return genderInput;
        }

        public static string PositionValid(string positionInput)
        {
            while (!Enum.TryParse(positionInput.ToLower(), true, out Position position)) { positionInput = ErrInput(); }
            return positionInput;
        }

        public static DateTime DateValid(string dateInput)
        {
            while (!DateTime.TryParse(dateInput, out DateTime date) || date.Year > 2025) { dateInput = ErrInput(); }
            return DateTime.Parse(dateInput);
        }

        public static double NumberValid(string numberInput)
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
                Console.Write("\n Neispravan unos. Unesite opet.");

                if (text == "0") { Console.Write("\n\nOdabir: "); }
                else { Console.Write("\n {0}\n\nOdabir: ", text); }

                input_input = Console.ReadLine();
            }
            return int.Parse(input_input);
        }

        public static string NameValid(string name_input, string type)
        {
            bool valid = name_input.All(Char.IsLetter);
            while (valid == false)
            {
                Console.WriteLine("\nNeispravan unos. Unesite opet. \n");
                if (type == "name") { Console.Write("\n\nUnesite ime: "); }
                else if (type == "surname") { Console.Write("\n\nUnesite prezime: "); }
                name_input = Console.ReadLine();
                valid = name_input.All(Char.IsLetter);
            }
            name_input = char.ToUpper(name_input[0]) + name_input.Substring(1).ToLower();
            return name_input;
        }

        public static bool Confirmation(int id, string type)
        {
            Console.Write("\nJeste li sigurni da želite izmjeniti {0}? (y/n): ", id); 
            //provjera jel unos uopce dobar myb ? 
            //mozda nije ni potrebno tbh 
            var message = Console.ReadLine();
            if (message.ToLower() == "y" || message.ToLower() == "yes" || message.ToLower() == "da")
            {
                Console.WriteLine("Uspješno {0}", type);
                Continue();
                return true;
            }
            else
            {
                Console.WriteLine("Otkazano {0}", type);
                Continue();
                return false;
            }
        }

        public static void Continue()
        {
            Console.WriteLine("\nPritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static string ErrInput()
        {
            Console.Write("\nNeispravan unos. \nUnesite opet:");
            return Console.ReadLine();
        }
    }
}
