using System;

namespace GroupCMinesweeperMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!!");
            Console.WriteLine("Please select the size of your board: ");
            Console.ReadLine();

            //You user input to select game board size - Taylore

            //Ask what you want to do next (flag or uncover) - Jennifer
            bool continuePlay = true;
            do
            {
                GetUserNextPlay();
            } while (continuePlay);
        } //end Main

        private static void GetUserNextPlay()
        {
            Console.WriteLine("What is your next move? ");
            Console.WriteLine("Do you want to: ");
            Console.WriteLine("1) Uncover a cell");
            Console.WriteLine("2) Flag a cell");
            Console.WriteLine("3) Remove a flag");
            bool inputValid = true;
            do
            {
                Console.Write("Please enter 1, 2 or 3: ");
                var userChoice = int.TryParse(Console.ReadLine(), out int playChoice);
                if (!userChoice || playChoice < 1 || playChoice > 3)
                {
                    inputValid = false;
                    Console.WriteLine("You have entered an invalid choice. Please try again! ");
                } //end if
                else
                {
                    switch (playChoice)
                    {
                        case 1:
                            UncoverCell();
                            break;
                        case 2:
                            FlagCell();
                            break;
                        case 3:
                            RemoveFlag();
                            break;
                    }//end switch
                }//end else
            } while (!inputValid);
        }

        public static void UncoverCell()
        {
            Console.WriteLine("What cell would you like to uncover? ");
            Console.ReadLine();
            if(bombPresent = true)
            {
                Console.WriteLine("Game Over");
                continuePlay = false;
                DisplayBoard();
            }
            else
            {
                if (numBombs = 0)
                {

                }
            }
        }

        public static void FlagCell()
        {

        }

        public static void RemoveFlag()
        {

        }

    }//end class Program
} //end Namespace
