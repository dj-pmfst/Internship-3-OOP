namespace Aerodrom
{
    internal class Menus : Funcionality
    {
        public static int FlightsMenuInput()
        {
            Console.Clear();
            Console.Write("Letovi \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih letova \n 2-Dodavanje leta " +
                "\n 3-Pretraživanje letova \n 4-Uređivanje leta " +
                "\n 5-Brisanje leta \n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 5);
            return input;
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
        public static int PlanesMenuInput()
        {
            Console.Clear();
            Console.Write("Avioni \n \n ");
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Prikaz svih aviona \n 2-Dodavanje novog aviona " +
                "\n 3-Pretraživanje aviona \n 4-Brisanje aviona " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 4);
            return input;
        }
        public static int SearchMenu(string type)
        {
            Console.Clear();
            Console.Write("{0} \n \n ", type);
            var menuText = "Unesite broj za željenu opciju " +
                "\n 1-Po ID-u \n 2-Po nazivu " +
                "\n 0-Povratak na prethodni izbornik";
            var input = InputValid(menuText, 2);
            return input;
        }
    }
}
