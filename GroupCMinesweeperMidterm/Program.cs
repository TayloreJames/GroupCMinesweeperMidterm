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

            //CreateMinefield(height, width, numBombs);
            var minefield1 = new Minefield(10, 10, 4);
           minefield1.PrintMinefield(minefield1.MinefieldArray, minefield1.NumRows, minefield1.NumColumns);

            //    bool continuePlay = true;
            //    do
            //    {
            //        GetUserNextPlay();
            //    } while (continuePlay);
            //} //end Main

            //private static void GetUserNextPlay()
            //{
            /*
            bool validInput = true;
            do
            {
                Console.WriteLine("Please select a cell for your next move: ");
                Console.WriteLine("Please enter a column letter: ");
                var columnLet = Console.ReadLine();
                Console.WriteLine("Please enter a row number: ");
                var rowLet = int.TryParse(Console.ReadLine(), out rowMove);
            //  add if statement to check for valid row and column
            } while (!validInput); 
            */
            //    Console.WriteLine("What is your next move? ");
            //    Console.WriteLine("Do you want to: ");
            //    Console.WriteLine("1) Uncover a cell");
            //    Console.WriteLine("2) Flag a cell");
            //    Console.WriteLine("3) Remove a flag");
            //    bool inputValid = true;
            //    do
            //    {
            //        Console.Write("Please enter 1, 2 or 3: ");
            //        var userChoice = int.TryParse(Console.ReadLine(), out int playChoice);
            //        if (!userChoice || playChoice < 1 || playChoice > 3)
            //        {
            //            inputValid = false;
            //            Console.WriteLine("You have entered an invalid choice. Please try again! ");
            //        } //end if
            //        else
            //        {
            //            switch (playChoice)
            //            {
            //                case 1:
            //                    UncoverCell(rowMove, columnMove);
            //                    break;
            //                case 2:
            //                    FlagCell(rowMove, columnMove);
            //                    break;
            //                case 3:
            //                    RemoveFlag(rowMove, columnMove);
            //                    break;
            //            }//end switch
            //        }//end else
            //    } while (!inputValid);
            //}
        }
    }//end class Program
} //end Namespace
