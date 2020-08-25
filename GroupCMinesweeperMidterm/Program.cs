using System;

namespace GroupCMinesweeperMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!!");
            Console.WriteLine("Please select the number of rows: ");
            int numRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select the number of columns: ");
            int numColumns = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select the number of bombs: ");
            int numBombs = int.Parse(Console.ReadLine());

            //CreateMinefield(height, width, numBombs);
            var minefield1 = new Minefield(numRows, numColumns, numBombs);


            //minefield1.PrintMinefield();
            //Console.WriteLine(minefield1.MinefieldArray[3, 5].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[5, 2].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[1, 6].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[4, 3].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[7, 9].EmptyCell);
            //Console.ReadKey();


            //    bool continuePlay = true;
            //    do
            //    {
            //        continuePlay = GetUserNextPlay();
            //    } while (continuePlay);
            //} //end Main

            //public static void GetUserNextPlay()
            //{
            //    int columnCoordinate;
            //    int rowCoordinate;

            //    bool validInput = true;
            //    do
            //    {
            //        Console.WriteLine("Please select a cell for your next move: ");
            //        Console.WriteLine("Please enter a column letter: ");
            //        columnCoordinate = Convert.ToInt32(Convert.ToChar(Console.ReadLine().ToUpper())) - 65;
            //        Console.WriteLine("Please enter a row number: ");
            //        rowCoordinate = int.Parse(Console.ReadLine());

            //        //  add if statement to check for valid row and column
            //    } while (!validInput);

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
            //                    UncoverCell(rowCoordinate, columnCoordinate);
            //                    break;
            //                case 2:
            //                    FlagCell(rowCoordinate, columnCoordinate);
            //                    break;
            //                case 3:
            //                    RemoveFlag(rowCoordinate, columnCoordinate);
            //                    break;
            //            }//end switch
            //        }//end else
            //    } while (!inputValid);
            //}
        }

    }//end class Program
    }
}// end Namespace
