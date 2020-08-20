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


            //    bool continuePlay = true;
            //    do
            //    {
            //        GetUserNextPlay();
            //    } while (continuePlay);
            //} //end Main

            //private static void GetUserNextPlay()
            //{
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
            //                    UncoverCell();
            //                    break;
            //                case 2:
            //                    FlagCell();
            //                    break;
            //                case 3:
            //                    RemoveFlag();
            //                    break;
            //            }//end switch
            //        }//end else
            //    } while (!inputValid);
            //}
        }
    }//end class Program
} //end Namespace
