namespace TicTacToeLogic
{
    public class Cell
    {
        private eCellValue m_CellState;
        // $G$ NTT-999 (-5) This member should have been readonly.
        private int m_RowIndex;
        private int m_ColumnIndex;

        public Cell(int i_RowIndex, int i_ColumnIndex)
        {
            m_CellState = eCellValue.Empty;
            m_RowIndex = i_RowIndex;
            m_ColumnIndex = i_ColumnIndex;
        }

        public int RowIndex
        {
            get
            {
                return m_RowIndex;
            }
        }

        public int ColumnIndex
        {
            get
            {
                return m_ColumnIndex;
            }
        }

        public eCellValue CellState
        {
            get
            {
                return m_CellState;
            }

            set
            {
                m_CellState = value;
            }
        }

        public bool IsEmpty()
        {
            return CellState == eCellValue.Empty;
        }

        public void InsertSymbol(eCellValue i_Symbol)
        {
                CellState = i_Symbol == eCellValue.X ? eCellValue.X : eCellValue.O;
        }
    }
}
