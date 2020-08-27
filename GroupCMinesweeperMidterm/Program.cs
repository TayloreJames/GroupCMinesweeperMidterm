using System;

namespace GroupCMinesweeperMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!!");
            Console.WriteLine("Please select the number of rows (max of 26): ");
            int numRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select the number of columns (max of 26): ");
            int numColumns = int.Parse(Console.ReadLine());
            Console.WriteLine("Please select the number of bombs: ");
            int numBombs = int.Parse(Console.ReadLine());

            //CreateMinefield(height, width, numBombs);
            var minefield1 = new Minefield(numRows, numColumns, numBombs);
            minefield1.PrintCoveredMinefield();


            //minefield1.PrintMinefield();
            //Console.WriteLine(minefield1.MinefieldArray[3, 5].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[5, 2].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[1, 6].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[4, 3].EmptyCell);
            //Console.WriteLine(minefield1.MinefieldArray[7, 9].EmptyCell);
            //Console.ReadKey();


            bool continuePlay = true;
            do
            {
                continuePlay = minefield1.GetUserNextPlay();
            } while (continuePlay);
        } 

    }//end class Program
}// end Namespace
