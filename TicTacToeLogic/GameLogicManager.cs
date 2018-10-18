using System;
using System.Drawing;

namespace TicTacToeLogic
{
    public class GameLogicManager
    {
        private readonly Board r_GameBoard;
        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private readonly eGameMode r_GameMode;
        private readonly Random r_Random = new Random();
        private eGameState m_GameState;
        private bool m_IsFirstPlayerTurn;
        private int m_MoveCounter;

        public delegate void BoardChangedEventHandler(Point i_Point, eCellValue i_Symbol);
        // $G$ SFN-011 (16) Bonus: BL events are handled in the UI.
        public event BoardChangedEventHandler OnLogicBoardChanged;

        public GameLogicManager(int i_BoardSize, eGameMode i_GameMode, Player i_PlayerOne, Player i_PlayerTwo)
        {
            r_GameBoard = new Board(i_BoardSize);
            r_GameMode = i_GameMode;
            r_PlayerOne = i_PlayerOne;
            r_PlayerTwo = i_PlayerTwo;
        }

        public Board GameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        public eGameState GameState
        {
            get
            {
                return m_GameState;
            }

            set
            {
                m_GameState = value;
            }
        }

        public eGameMode GameMode
        {
            get
            {
                return r_GameMode;
            }
        }

        public Cell[,] BoardGameCells
        {
            get
            {
                return r_GameBoard.BoardGameCells;
            }
        }

        public int BoardSize
        {
            get
            {
                return r_GameBoard.BoardSize;
            }
        }

        public Random Random
        {
            get
            {
                return r_Random;
            }
        }

        public Player CurrentPlayerTurn
        {
            get
            {
                return m_IsFirstPlayerTurn ? r_PlayerOne : r_PlayerTwo;
            }
        }

        public bool FirstPlayerTurn
        {
            get
            {
                return m_IsFirstPlayerTurn;
            }

            set
            {
                m_IsFirstPlayerTurn = value;
            }
        }

        public int MoveCounter
        {
            get
            {
                return m_MoveCounter;
            }

            set
            {
                m_MoveCounter = value;
            }
        }

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

        public void InitializeRound()
        {
            GameBoard.InitializeBoardCells();
            GameBoard.ClearBoard();
            MoveCounter = 0;
            FirstPlayerTurn = true;
        }

        private void setTie()
        {
            GameState = eGameState.Tie;
        }

        public void UpdateResultsToWinner()
        {
            GameState = eGameState.HasWinner;

            if (FirstPlayerTurn)
            {
                PlayerTwoInfo.PlayerScore++;
            }
            else
            {
                PlayerOneInfo.PlayerScore++;
            }
        }

        public void PlayerMove(Point i_GamePoint)
        {
            bool isPlayerLost;
            Cell selectedCell;

            MoveCounter++;

            selectedCell = BoardGameCells[i_GamePoint.X, i_GamePoint.Y];

            if (selectedCell.CellState == eCellValue.Empty)
            {
                selectedCell.InsertSymbol(CurrentPlayerTurn.Symbol);
            }

            isPlayerLost = examineIfPlayerMadeTheGameEnd(selectedCell, selectedCell.CellState);
            if (isPlayerLost)
            {
                UpdateResultsToWinner();
                OnLogicBoardChanged?.Invoke(i_GamePoint, CurrentPlayerTurn.Symbol);
            }
            else
            {
                if (GameBoard.IsFull(MoveCounter))
                {
                    setTie();
                    OnLogicBoardChanged?.Invoke(i_GamePoint, CurrentPlayerTurn.Symbol);
                }
                else
                {
                    OnLogicBoardChanged?.Invoke(i_GamePoint, CurrentPlayerTurn.Symbol);
                }
            }
        }

        private bool examineIfPlayerMadeTheGameEnd(Cell i_GameCell, eCellValue i_WantedCellState)
        {
            return isFoundRowSequence(i_GameCell, i_WantedCellState) || isFoundColumnSequence(i_GameCell, i_WantedCellState) || isFoundDiagonalSequence(i_GameCell, i_WantedCellState);
        }

        private bool isFoundDiagonalSequence(Cell i_GameCell, eCellValue i_WantedCellState)
        {
            bool firstDiagonalIsTrue = true;
            bool secondDiagonal = true;

            if (i_GameCell.RowIndex == i_GameCell.ColumnIndex)
            {
                for (int i = 0; i < BoardSize; i++)
                {
                    if (i_GameCell != BoardGameCells[i, i] && BoardGameCells[i, i].CellState != i_WantedCellState)
                    {
                        firstDiagonalIsTrue = false;
                        break;
                    }
                }
            }
            else
            {
                firstDiagonalIsTrue = false;
            }

            if (i_GameCell.RowIndex + i_GameCell.ColumnIndex == BoardSize - 1)
            {
                for (int i = 0; i < BoardSize; i++)
                {
                    if (i_GameCell != BoardGameCells[i, BoardSize - 1 - i] && BoardGameCells[i, BoardSize - 1 - i].CellState != i_WantedCellState)
                    {
                        secondDiagonal = false;
                        break;
                    }
                }
            }
            else
            {
                secondDiagonal = false;
            }

            return firstDiagonalIsTrue || secondDiagonal;
        }

        private bool isFoundRowSequence(Cell i_GameCell, eCellValue i_WantedCellState)
        {
            bool result = true;

            for (int i = 0; i < BoardSize; i++)
            {
                if (i_GameCell != BoardGameCells[i_GameCell.RowIndex, i] && BoardGameCells[i_GameCell.RowIndex, i].CellState != i_WantedCellState)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool isFoundColumnSequence(Cell i_GameCell, eCellValue i_WantedCellState)
        {
            bool result = true;

            for (int i = 0; i < BoardSize; i++)
            {
                if (i_GameCell != BoardGameCells[i, i_GameCell.ColumnIndex] && BoardGameCells[i, i_GameCell.ColumnIndex].CellState != i_WantedCellState)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private Cell randomizeFreeCell()
        {
            int randomRow;
            int randomColumn;

            do
            {
                randomRow = Random.Next(0, BoardSize);
                randomColumn = Random.Next(0, BoardSize);
            }
            while (!BoardGameCells[randomRow, randomColumn].IsEmpty());

            return BoardGameCells[randomRow, randomColumn];
        }

        public void MakeMoveAsCPU()
        {
            Cell cpuSelectedCell;
            Point SelectedCell = new Point();

            cpuSelectedCell = randomizeFreeCell();

            SelectedCell.X = cpuSelectedCell.RowIndex;
            SelectedCell.Y = cpuSelectedCell.ColumnIndex;
            PlayerMove(SelectedCell);
        }
    }
}