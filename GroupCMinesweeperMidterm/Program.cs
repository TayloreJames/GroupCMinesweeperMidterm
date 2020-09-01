using System;

namespace GroupCMinesweeperMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows = 0;
            int numColumns = 0;
            int numBombs = 0;
            bool validInput = true;
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Minesweeper!!");
                do
                {
                    Console.Write("Please select the number of rows (max of 26): ");
                    validInput = int.TryParse(Console.ReadLine(), out int tempRow);
                    if (validInput && tempRow > 0 && tempRow <= 26)
                    {
                        numRows = tempRow;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Try again.");
                        validInput = false;
                    }
                } while (!validInput);

                do
                {
                    Console.Write("Please select the number of columns (max of 26): ");
                    validInput = int.TryParse(Console.ReadLine(), out int tempColumn);
                    if (validInput && tempColumn > 0 && tempColumn <= 26)
                    {
                        numColumns = tempColumn;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Try again.");
                        validInput = false;
                    }
                } while (!validInput);

                do
                {
                    Console.Write($"Please select the number of bombs (max of {numColumns * numRows / 2}): ");
                    validInput = int.TryParse(Console.ReadLine(), out int tempBombs);
                    if (validInput && tempBombs > 0 && tempBombs <= (numColumns * numRows / 2))
                    {
                        numBombs = tempBombs;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Try again.");
                        validInput = false;
                    }
                } while (!validInput);

                Console.Clear();
                var minefield1 = new Minefield(numRows, numColumns, numBombs);
                minefield1.PrintCoveredMinefield();





                bool continuePlay = true;
                do
                {
                    continuePlay = minefield1.GetUserNextPlay();
                } while (continuePlay);

                var continueGame = new Continue();
                continueProgram = continueGame.DetermineStatus();
            }
        }
     
    }
}
