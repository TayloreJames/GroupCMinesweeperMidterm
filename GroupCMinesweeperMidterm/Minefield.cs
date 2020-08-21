using System;
namespace GroupCMinesweeperMidterm
{
    public class Minefield
    {

        public int NumRows { get; set; }
        public int NumColumns { get; set; }
        public int NumBombs { get; set; }

        public int NumFlags { get; set; }
        public Cell[,] MinefieldArray { get; set; }

        public Minefield(int numRows, int numColumns, int numBombs)
        {
            NumRows = numRows;
            NumColumns = numColumns;
            NumBombs = numBombs;
            NumFlags = numBombs;
            MinefieldArray = CreateMinefield(numRows, numColumns, numBombs);
        }

        /*
        public Cell[,] CreateMinefield(int height, int width, int numBombs)
        {
            var array = new Cell[height, width];
            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {
                    var cell = new Cell();
                    array[i, j] = cell;
                    Console.Write(array[i,j].CellChar);
                }
                Console.WriteLine();
            }
            return array;
        }
        */

        public Cell[,] CreateMinefield(int numRows, int numColumns, int numBombs)
        {
            var array = new Cell[numRows+1, numColumns+1];
            //Creates board of unknown squares
            char capitalAChar = Convert.ToChar(0x0041);
            
           // char unknown = '#';
            int numberOne = 1;
           
            for (int i = 0; i < numRows + 1; i++)
            {

                for (int j = 0; j < numColumns + 1; j++)
                {
                    var cell = new Cell();
                    array[i, j] = cell;
                    if (i == 0 && j < numColumns)
                    {
                        array[i, j].CellString = Convert.ToString(capitalAChar);
                        capitalAChar++;
                        if (capitalAChar == '[')
                        {
                            capitalAChar = Convert.ToChar(0x0041);
                        }
                    }
                    else if (i == 0 && j == numColumns)
                    {
                        array[0, j].CellString = "  ";
                    }
                    else if (j == numColumns)
                    {
                        array[i, j].CellString = Convert.ToString(numberOne);
                        numberOne++;
                    }
 
                }
            }
            return array;
        }

        public void PrintMinefield(Cell[,] minefield, int numRows, int numColumns )
        { 

            //Print Board
           for (int i = 0; i < numRows + 1; i++)
           {
                for (int j = 0; j < numColumns + 1; j++)
                {
                    Console.Write(minefield[i, j].CellString);
                }
                Console.WriteLine();
           }

        }
    }
}
