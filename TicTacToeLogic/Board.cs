namespace TicTacToeLogic
{
    public class Board
    {
        private readonly int r_BoardSize;
        private Cell[,] m_Board;

        public Board(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            InitializeBoardCells();
        }

        public Cell[,] BoardGameCells
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public void InitializeBoardCells()
        {
            BoardGameCells = new Cell[BoardSize, BoardSize];

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    BoardGameCells[i, j] = new Cell(i, j);
                }
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    BoardGameCells[i, j].CellState = eCellValue.Empty;
                }
            }
        }

        public bool IsFull(int i_MoveCounter)
        {
            return i_MoveCounter == BoardSize * BoardSize;
        }
    }
}
