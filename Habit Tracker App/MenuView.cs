namespace Habit_Tracker_App
{
    public static class MenuView
    {
        public static void DisplayMainMenu()
        {
            bool exitMenu = false;
            string menuSelection = "";
            while (!exitMenu)
            {
                Console.WriteLine("1. Insert Habit");
                Console.WriteLine("2. Delete Habit");
                Console.WriteLine("3. Update Habit");
                Console.WriteLine("4. View All Habits");
                Console.WriteLine("0. Exit");
                int selectedOption = 0;
                bool validInputTwo = int.TryParse(Console.ReadLine(), out selectedOption);
                if (validInputTwo && selectedOption >= 0 && selectedOption < 5)
                {
                    menuSelection = selectedOption.ToString();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                    // Restart the loop to prompt the user again
                    continue;
                }
                switch (menuSelection)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "0":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, Please enter a number between 0 and 4.");
                        break;
                }
            }
        }
    }
}
