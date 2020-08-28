using System;
namespace GroupCMinesweeperMidterm
{
    public class Continue
    {
        private string UserInput { get; set; }

        public bool DetermineStatus()
        {
            Console.Write("\n Would you like to play again? (y/n): ");
            UserInput = Console.ReadLine();

            while (true)
            {
                if (UserInput == "y")
                {
                    Console.WriteLine();
                    return true;
                }
                else if (UserInput == "n") return false;
                else
                {
                    Console.Write("Invalid entry. Please select y to continue the program or n to cancel: ");
                    UserInput = Console.ReadLine();
                }
            }
        }
    }
}
