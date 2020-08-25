  using System;
namespace GroupCMinesweeperMidterm
{
    public class Cell
    {
        //Member Fields
        private bool _emptyCell;
        private string whiteFlag = Convert.ToString(Convert.ToChar(0x2691));


        //Properties
        public bool BombPresent { get; set; }
        public bool NumPresent { get; set; }
        public bool FlagPresent { get; set; }
        public bool CellCovered { get; set; }
        public bool EmptyCell
        {
            get
            {
                if (BombPresent == false && NumPresent == false)
                {
                    _emptyCell = true;
                }
                else _emptyCell = false;

                return _emptyCell;
            }

        }
        public string CellStringCovered
        {
            get
            {
                if (FlagPresent) return whiteFlag;
                else return "#";
            }
        }
        public string CellStringUncovered { get; set; }




        //Constructors
        public Cell()
        {
            BombPresent = false;
            NumPresent = false;
            FlagPresent = false;
            CellCovered = true;
            CellStringUncovered = Convert.ToString(Convert.ToChar(0x2610));

        }

        


        

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
