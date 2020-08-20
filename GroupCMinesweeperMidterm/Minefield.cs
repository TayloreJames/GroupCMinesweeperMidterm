using System;
namespace GroupCMinesweeperMidterm
{
    public class Minefield
    {

        public int Height { get; set; }
        public int Width { get; set; }
        public int NumBombs { get; set; }
        public Cell[,] MinefieldArray { get; set; }

        public Minefield(int height, int width, int numBombs)
        {
            Height = height;
            Width = width;
            NumBombs = numBombs;
            MinefieldArray = CreateMinefield(height, width, numBombs);
        }

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
    }
}
