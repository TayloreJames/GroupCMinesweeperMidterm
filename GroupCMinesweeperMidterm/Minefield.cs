using System;
namespace GroupCMinesweeperMidterm
{
    public class Minefield
    {
        //Member Fields
        private string bomb = Convert.ToString(Convert.ToChar(0x2600));
        private char capitalAChar = Convert.ToChar(0x0041);
        private int numberOne = 1;

        //Properties
        public int NumRows { get; set; }
        public int NumColumns { get; set; }
        public int NumBombs { get; set; }
        public int NumFlags { get; set; }
        public Cell[,] MinefieldArray { get; set; }

        //Constructors
        public Minefield(int numRows, int numColumns, int numBombs)
        {
            NumRows = numRows;
            NumColumns = numColumns;
            NumBombs = numBombs;
            NumFlags = numBombs;
            MinefieldArray = CreateMinefield();
        }

        //Methods
        public Cell[,] CreateMinefield()
        {
            var minefield = new Cell[NumRows+1, NumColumns+1];

            for (int i = 0; i < NumRows + 1; i++)
            {

                for (int j = 0; j < NumColumns + 1; j++)
                {
                    var cell = new Cell();
                    minefield[i, j] = cell;
                    //alphabetic coordinates for columns
                    if (i == 0 && j < NumColumns)
                    {
                        minefield[i, j].CellStringUncovered =Convert.ToString(capitalAChar);

                        capitalAChar++;
                        if (capitalAChar == '[')
                        {
                            capitalAChar = Convert.ToChar(0x0041);
                        }
                    }
                    //blank space upper right hand corner of board
                    else if (i == 0 && j == NumColumns)
                    {
                        minefield[0, j].CellStringUncovered = "  ";
                    }
                    //numeric coordinates for rows
                    else if (j == NumColumns)
                    {
                        minefield[i, j].CellStringUncovered = " " + Convert.ToString(numberOne);
                        numberOne++;
                    }
 
                }
            }
            PopulateBombs(minefield);
            PopulateNumberedCells(minefield);
            
            return minefield;
        }

       

        public void PopulateBombs(Cell[,] minefield)
        {
            var random = new Random();
            for (int i = 0; i < NumBombs; i++)
            {

                var rowRandom = random.Next(1, NumRows + 1);
                var columnRandom = random.Next(0, NumColumns);

                if (minefield[rowRandom, columnRandom].CellStringUncovered != bomb)
                {
                    minefield[rowRandom, columnRandom].CellStringUncovered = bomb;
                    minefield[rowRandom, columnRandom].BombPresent = true;

                }
                else i--;
            }
        }

        public void PopulateNumberedCells(Cell[,] minefield)
        {
            int counter = 0;
            for (int i = 1; i < NumRows + 1; i++)
            {
                for (int j = 0; j < NumColumns; j++)
                {
                    //checking around given square

                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (k >= 1 && k < NumRows + 1 && l >= 0 && l < NumColumns)
                            {
                                if (minefield[k, l].BombPresent)
                                {
                                    counter++;
                                }
                            }
                        }
                    }
                    if (counter > 0 && !minefield[i, j].BombPresent)
                    {
                        minefield[i, j].CellStringUncovered = Convert.ToString(counter);
                        minefield[i, j].NumPresent = true;
                    }

                    counter = 0;
                }
            }
        }

        public void PrintUncoveredMinefield()
        {

           for (int i = 0; i < NumRows + 1; i++)
           {
                for (int j = 0; j < NumColumns + 1; j++)
                {
                    Console.Write(MinefieldArray[i, j].CellStringUncovered);
                }
                Console.WriteLine();
           }

        }

        public bool GetUserNextPlay()
        {
            int columnCoordinate;
            int rowCoordinate;

            bool validInput = true;
            do
            {
                Console.WriteLine("Please select a cell for your next move: ");
                Console.WriteLine("Please enter a column letter: ");
                columnCoordinate = Convert.ToInt32(Convert.ToChar(Console.ReadLine().ToUpper())) - 65;
                Console.WriteLine("Please enter a row number: ");
                rowCoordinate = int.Parse(Console.ReadLine());

                //  add if statement to check for valid row and column
            } while (!validInput);

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
                            return UncoverCell(rowCoordinate, columnCoordinate);                       
                            
                        case 2:
                            FlagCell(rowCoordinate, columnCoordinate);
                            return true;
                        case 3:
                            RemoveFlag(rowCoordinate, columnCoordinate);
                            return true;
                    }//end switch
                }//end else
            } while (!inputValid);
            return true;
        }

        public bool UncoverCell(int rowCoordinate, int columnCoordinate)
        {
            
            if (MinefieldArray[rowCoordinate, columnCoordinate].BombPresent)
            {
                Console.WriteLine("GAME OVER! You've stepped on a land mine peasant.");
                Console.WriteLine();
                PrintUncoveredMinefield();
                return false;
                
            }
            else if (MinefieldArray[rowCoordinate, columnCoordinate].NumPresent)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].CellCovered = false;

                foreach (var cell in MinefieldArray)
                {
                    if (cell.CellCovered && !cell.BombPresent)
                    {
                        return true;
                    }
                }
                Console.WriteLine("CONGRATULATIONS! YOU'RE A WINNER!");
                PrintUncoveredMinefield();
                return false;

            }


            //checking around given square
            for (int k = rowCoordinate - 1; k <= rowCoordinate + 1; k++)
            {
                for (int l = columnCoordinate - 1; l <= columnCoordinate + 1; l++)
                {
                    //making sure not to add 
                    if (k >= 0 && k < NumRows && l >= 0 && l < NumColumns)
                    {
                        if (k != rowCoordinate || l != columnCoordinate)
                        {
                            if (searchArray[k, l] == "#")
                            {

                                searchArray[k, l] = Convert.ToString(Convert.ToChar(0x2610));
                                FlipEmpties(searchArray, k, l);
                            }
                        }
                        else if (searchArray[k, l] == "#") searchArray[rowCoordinate, columnCoordinate] = Convert.ToString(Convert.ToChar(0x2610));

                    }
                }
            }
        }

        public void FlagCell(int rowCoordinate, int columnCoordinate)
        {
            if (NumFlags > 0 && MinefieldArray[rowCoordinate, columnCoordinate].CellCovered == true)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent = true;
                NumFlags--;
            }
            else
            {
                Console.WriteLine("Cannot place flag at this location");
            }
        }

        public void RemoveFlag(int rowCoordinate, int columnCoordinate)
        {
            if (MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent == true)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent = false;
                NumFlags++;
            }
            else
            {
                Console.WriteLine("There are no flags at this location.");
            }
        }

    }
}
