using System;
namespace GroupCMinesweeperMidterm
{
    public class Cell
    {
        public bool BombPresent { get; set; }
        public bool NumPresent { get; set; }
        public bool FlagPresent { get; set; }
        public bool CellCovered { get; set; }
        public bool EmptyCell { get; set; }
        public string CellString { get; set; }

        public Cell()
        {
            BombPresent = false;
            NumPresent = false;
            FlagPresent = false;
            CellCovered = true;
            EmptyCell = true;
            CellString = "#";

        }


        //public static void UncoverCell(int rowMove, int columnMove)
        //{
        //    Console.WriteLine("What cell would you like to uncover? ");
        //    Console.ReadLine();
        //    if (bombPresent = true)
        //    {
        //        Console.WriteLine("Game Over");
        //        continuePlay = false;
        //        DisplayBoard();
        //    }
        //    else
        //    {
        //        if (numBombs = 0)
        //        {

        //        }
        //    }
        //}

       // public static Cell[,] FlagCell(int rowMove, int columnMove, Cell[,] minefieldArray)
      //  {
      //      minefieldArray[rowMove, columnMove].FlagPresent = true;
      //      numFlags -=; 
      //  }
      /*
        public static void RemoveFlag(int rowMove, int columnMove)
        {

        }
      */
    }
}
