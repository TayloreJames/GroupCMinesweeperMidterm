using System;
namespace GroupCMinesweeperMidterm
{
    public class Minefield
    {
        //Member Fields
        private string bomb = Convert.ToString(Convert.ToChar(0x2600));
        private char capitalAChar = Convert.ToChar(0x0041);
        private string whiteFlag = Convert.ToString(Convert.ToChar(0x2691));
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
                        minefield[i, j].CellCovered = false;

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
                        minefield[0, j].CellCovered = false;
                    }
                    //numeric coordinates for rows
                    else if (j == NumColumns)
                    {
                        minefield[i, j].CellStringUncovered = " " + Convert.ToString(numberOne);
                        minefield[i, j].CellCovered = false;
                        numberOne++;
                    }
 
                }
            }
            PopulateBombs(minefield);
            PopulateNumberedCells(minefield);
            PopulateEmptyCells(minefield);
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
            //loops through entire game board
            for (int i = 1; i < NumRows + 1; i++)
            {
                for (int j = 0; j < NumColumns; j++)
                {
                    //begins search around given loop
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

        public void PopulateEmptyCells(Cell[,] minefield)
        {
            for(int i = 1; i < NumRows + 1; i++)
            {
                for(int j = 0; j < NumColumns; j++)
                {
                    if (minefield[i, j].EmptyCell == true)
                    {
                        minefield[i, j].CellStringUncovered = " ";
                    }
                }
            }
        }

        public void PrintUncoveredMinefield()
        {
            Console.WriteLine();
            for (int i = 0; i < NumRows + 1; i++)
            {
                for (int j = 0; j < NumColumns + 1; j++)
                {
                    Console.Write(MinefieldArray[i, j].CellStringUncovered);
                }
                Console.WriteLine();
            }

        }

        public void PrintCoveredMinefield()
        {       
            for (int i = 0; i < NumRows + 1; i++)
            {
                for (int j = 0; j < NumColumns + 1; j++)
                {
                    if (MinefieldArray[i, j].CellCovered)
                    {
                        if (MinefieldArray[i, j].FlagPresent)
                        {
                            Console.Write(whiteFlag);
                        }
                        else
                        {
                            Console.Write("#");
                        }
                    }
                    else
                    {
                        Console.Write(MinefieldArray[i, j].CellStringUncovered);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{NumFlags} Flag/s Remain");
            Console.WriteLine();

        }

        public bool GetUserNextPlay()
        {
            int columnCoordinate = 0;
            int rowCoordinate = 0;

            bool validInputRow = true;
            bool validInputColumn = true;
            char tempColumn='a';
            
            Console.WriteLine("Please select a cell for your next move ");            
            do
            {
                Console.Write("Please enter a column letter: ");
                var stringColumn = Console.ReadLine().ToUpper();
                if (stringColumn.Length > 1)
                {
                    validInputColumn = false;
                }
                else
                {
                    tempColumn = Convert.ToChar(stringColumn);
                }
                if (Char.IsLetter(tempColumn))
                {
                    columnCoordinate = Convert.ToInt32(tempColumn) - 65;
                    validInputColumn = true;
                }
                else validInputColumn = false;
                          
                Console.Write("Please enter a row number: ");

                if (int.TryParse(Console.ReadLine(), out int validRow))
                {
                    rowCoordinate = validRow;
                    if (rowCoordinate > 0 && rowCoordinate <= NumRows && columnCoordinate >= 0 && columnCoordinate < NumColumns && MinefieldArray[rowCoordinate, columnCoordinate].CellCovered == true)
                    {
                        validInputRow = true;
                    }
                    else validInputRow = false;
                }
                else validInputRow = false;

                if(!validInputRow || !validInputColumn)
                {
                    Console.WriteLine("\nInvalid entry. Please select again.\n");
                }
                
                
            } while (!validInputRow || !validInputColumn);


            Console.WriteLine("\nWhat is your next move? ");
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
                }
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
                    }
                }
            } while (!inputValid);
            return true;
        }

        public bool UncoverCell(int rowCoordinate, int columnCoordinate)
        {
            if(MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent = false;
                NumFlags++;
            }
            if (MinefieldArray[rowCoordinate, columnCoordinate].BombPresent)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER! You've stepped on a land mine peasant.");                
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
                        Console.Clear();
                        PrintCoveredMinefield();
                        return true;
                    }
                }
                Console.Clear();
                Console.WriteLine("CONGRATULATIONS! YOU'RE A WINNER!");
                PrintUncoveredMinefield();
                return false;

            }
            else
            {
                FlipEmpties(rowCoordinate, columnCoordinate);
                foreach (var cell in MinefieldArray)
                {
                    if (cell.CellCovered && !cell.BombPresent)
                    {
                        Console.Clear();
                        PrintCoveredMinefield();
                        return true;
                    }
                }
                Console.Clear();
                Console.WriteLine("CONGRATULATIONS! YOU'RE A WINNER!");
                PrintUncoveredMinefield();
                return false;

            }
        }
        public void FlipEmpties(int rowCoordinate, int columnCoordinate)
        {
            //Flip given cell
            if (MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent == true) NumFlags++;
            MinefieldArray[rowCoordinate, columnCoordinate].CellCovered = false;

            //Search around the given cell
            for (int k = rowCoordinate - 1; k <= rowCoordinate + 1; k++)
            {
                for (int l = columnCoordinate - 1; l <= columnCoordinate + 1; l++)
                {
                    //Makes sure cell we're checking is wihtin bounds
                    if (k > 0 && k < NumRows + 1 && l >= 0 && l < NumColumns)
                    {
                        //Makes sure center cell doesnt start FlipEmpties over again
                        if (k != rowCoordinate || l != columnCoordinate)
                        {
                            if (MinefieldArray[k, l].CellStringUncovered == " " && MinefieldArray[k, l].CellCovered == true)
                            {

                                MinefieldArray[k, l].CellCovered = false;
                                FlipEmpties(k, l);
                            }
                            else if (MinefieldArray[k, l].NumPresent == true)
                            {
                                if (MinefieldArray[k, l].FlagPresent == true) NumFlags++;
                                MinefieldArray[k, l].CellCovered = false;
                                
                            }
                        }

                    }
                }
            }
        }

        public void FlagCell(int rowCoordinate, int columnCoordinate)
        {
            if (NumFlags > 0 && MinefieldArray[rowCoordinate, columnCoordinate].CellCovered == true && MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent == false)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent = true;
                NumFlags--;
                Console.Clear();
                PrintCoveredMinefield();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot place flag at this location");        
                PrintCoveredMinefield();
            }
            
        }

        public void RemoveFlag(int rowCoordinate, int columnCoordinate)
        {
            if (MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent == true && MinefieldArray[rowCoordinate, columnCoordinate].CellCovered == true)
            {
                MinefieldArray[rowCoordinate, columnCoordinate].FlagPresent = false;
                NumFlags++;
                Console.Clear();
                PrintCoveredMinefield();
            }
            else
            {
                Console.Clear();
                PrintCoveredMinefield();
                Console.WriteLine("Error. There are no flags at this location.\n");
            }
            
            
        }

    }
}
