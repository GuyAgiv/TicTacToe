namespace TicTacToeLogic
{
    public class Player
    {
        private string m_PlayerName;
        private int m_PlayerScore;
        private eCellValue m_Symbol;

        public Player(eCellValue i_Symbol, string i_Name)
        {
            m_PlayerName = i_Name;
            m_Symbol = i_Symbol;
            m_PlayerScore = 0;
        }

        public eCellValue Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
        }

        public int PlayerScore
        {
            get
            {
                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore++;
            }
        }
    }
}
