using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace TicTacToiUI
{
    public partial class TicTacToeGameForm : Form
    {
        private const string k_ComputerName = "Computer";
        private const int k_ButtonSize = 70;
        private const int k_DefaultPadding = 5;
        private const int k_FooterHeight = 25;
        private readonly Size r_DefaultButtonSize = new Size(k_ButtonSize, k_ButtonSize);
        private readonly GameLogicManager r_TicTacToeManager;
        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private readonly List<TicTacToeCellButton> r_CellButtons = new List<TicTacToeCellButton>();
        private Player m_CurrentPlayer;
        
        public TicTacToeGameForm(string i_PlayerOneName, string i_PlayerTwoName, int i_Size, eGameMode i_GameMode)
        {
            InitializeComponent();
            r_PlayerOne = new Player(eCellValue.X, i_PlayerOneName);
            r_PlayerTwo = new Player(eCellValue.O, i_PlayerTwoName);
            r_TicTacToeManager = new GameLogicManager(i_Size, i_GameMode, PlayerOneInfo, PlayerTwoInfo);

            r_TicTacToeManager.OnLogicBoardChanged += r_TicTacToe_OnGUIBoardChange;

            buildGUIBoard(i_Size);
            setLabelsPlayerNames();
            initializeNewGame();
        }

        private static Point calculateVisualPoint(Point i_LogicCordinates, Size i_ButtonSize, int i_Padding)
        {
            return new Point(
                (i_LogicCordinates.X * (i_ButtonSize.Width + i_Padding)) + i_Padding,
                (i_LogicCordinates.Y * (i_ButtonSize.Height + i_Padding)) + i_Padding);
        }

        private Size calculateClientSize(int i_BoardSize, Size i_ButtonSize, int i_Padding)
        {
            return new Size((i_BoardSize * (i_ButtonSize.Width + i_Padding)) + i_Padding, (i_BoardSize * (i_ButtonSize.Height + i_Padding)) + (i_Padding + k_FooterHeight));
        }

        private void r_TicTacToe_OnGUIBoardChange(Point i_Point, eCellValue i_Symbol)
        {
            TicTacToeCellButton button = getButtonByPoint(i_Point);

            button.SetSymbol(i_Symbol);
            button.Enabled = false;

            switch (GameLogicManager.GameState)
            {
                case eGameState.Tie:
                    showNewGameMessage(tieMessage());
                    break;
                case eGameState.HasWinner:
                    showNewGameMessage(winnerMessage());
                    break;
                case eGameState.Active:
                    togglePlayers();
                    break;
            }
        }
        //// Properties ////
        public Player PlayerOneInfo
        {
            get
            {
                return r_PlayerOne;
            }
        }

        public Player PlayerTwoInfo
        {
            get
            {
                return r_PlayerTwo;
            }
        }

        public GameLogicManager GameLogicManager
        {
            get
            {
                return r_TicTacToeManager;
            }
        }

        public List<TicTacToeCellButton> CellButtons
        {
            get
            {
                return r_CellButtons;
            }
        }

        public Size DefaultButtonSize
        {
            get
            {
                return r_DefaultButtonSize;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public int FooterHeight
        {
            get
            {
                return k_FooterHeight;
            }
        }

        public new int DefaultPadding
        {
            get
            {
                return k_DefaultPadding;
            }
        }

        public int ButtonSize
        {
            get
            {
                return k_ButtonSize;
            }
        }

        public string ComputerName
        {
            get
            {
                return k_ComputerName;
            }
        }
        //// End Properties ////
        private TicTacToeCellButton getButtonByPoint(Point i_Point)
        {
            return CellButtons[convertPointToIndexArray(i_Point)];
        }

        private int convertPointToIndexArray(Point i_Point)
        {
            return i_Point.X + (i_Point.Y * GameLogicManager.BoardSize);
        }

        private void showNewGameMessage(string i_MessageToUser)
        {
            if (MessageBox.Show(i_MessageToUser, "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                initializeNewGame();
            }
            else
            {
                Close();
            }
        }
        
        private string tieMessage()
        {
            return string.Format("Tie! {0}Would you like to play another round?", Environment.NewLine);
        }

        private void togglePlayers()
        {
            CurrentPlayer = getNextPlayer();
            GameLogicManager.FirstPlayerTurn = !GameLogicManager.FirstPlayerTurn;

            if (CurrentPlayer.PlayerName == ComputerName)
            {
                labelPlayer2N.Font = new Font(this.Font, FontStyle.Bold);
                GameLogicManager.MakeMoveAsCPU();
                DrawLabelsBoldAndRegularRespectively(labelPlayer1N, labelPlayer2N);
            }
        }

        ////We decided that this method will not return value, cause anyway Label and Font are references type (so we can change their value within the method)
        // $G$ CSS-999 (-3) Private methods should start with a lowercase letter.
        private void DrawLabelsBoldAndRegularRespectively(Label io_Label1ToBold, Label io_Label2ToRegular)
        {
            io_Label1ToBold.Font = new Font(Font, FontStyle.Bold);
            io_Label2ToRegular.Font = new Font(Font, FontStyle.Regular);
        }

        private string winnerMessage()
        {
            return string.Format("The winner is {0}!{1}Would you like to play another round?", getNextPlayer().PlayerName, Environment.NewLine);
        }

        private Player getNextPlayer()
        {
            return CurrentPlayer == PlayerOneInfo ? PlayerTwoInfo : PlayerOneInfo;
        }

        private void initializeNewGame()
        {
            CurrentPlayer = PlayerOneInfo;
            GameLogicManager.GameState = eGameState.Active;
            GameLogicManager.InitializeRound();
            resetTicTacToeButtons();
            updateLabelsScores();
        }

        private void resetTicTacToeButtons()
        {
            foreach (TicTacToeCellButton ticTacToeCellButton in CellButtons)
            {
                ticTacToeCellButton.SetSymbol(eCellValue.Empty);
                ticTacToeCellButton.Enabled = true;
            }
        }

        private void updateLabelsScores()
        {
            labelPlayer1Score.Text = PlayerOneInfo.PlayerScore.ToString();
            labelPlayer2Score.Text = PlayerTwoInfo.PlayerScore.ToString();
        }

        private void setLabelsPlayerNames()
        {
            labelPlayer1N.Text = PlayerOneInfo.PlayerName + " : ";
            labelPlayer2N.Text = PlayerTwoInfo.PlayerName + " : ";
        }

        private void buildGUIBoard(int i_BoardSize)
        {
            for (int col = 0; col < i_BoardSize; col++)
            {
                for (int row = 0; row < i_BoardSize; row++)
                {
                    addCellButton(new Point(row, col));
                }
            }

            ClientSize = calculateClientSize(i_BoardSize, DefaultButtonSize, DefaultPadding);
        }

        private void addCellButton(Point i_LogicCordinates)
        {
            TicTacToeCellButton cellButton = new TicTacToeCellButton(i_LogicCordinates)
            {
                Size = DefaultButtonSize,
                Location = calculateVisualPoint(i_LogicCordinates, DefaultButtonSize, DefaultPadding)
            };

            CellButtons.Add(cellButton);
            cellButton.Click += CellButton_Click;
            cellButton.MouseEnter += CellButton_MouseEnter;
            cellButton.MouseLeave += CellButton_MouseLeave;
            Controls.Add(cellButton);
        }

        private void CellButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Enabled)
            {
                btn.Text = string.Empty;
            }
        }

        private void CellButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.Text = CurrentPlayer.Symbol.ToString();
        }
        
        private void CellButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            TicTacToeCellButton ticTacToeCellButton = i_Sender as TicTacToeCellButton;

            if (CurrentPlayer.PlayerName == PlayerOneInfo.PlayerName)
            {
                DrawLabelsBoldAndRegularRespectively(labelPlayer2N, labelPlayer1N);
            }
            else
            {
                DrawLabelsBoldAndRegularRespectively(labelPlayer1N, labelPlayer2N);
            }

            if (ticTacToeCellButton != null)
            {
                GameLogicManager.PlayerMove(ticTacToeCellButton.CellLocation);
            }
        }
    }
}
