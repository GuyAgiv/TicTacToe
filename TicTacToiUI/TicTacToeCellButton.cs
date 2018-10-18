using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace TicTacToiUI
{
    public class TicTacToeCellButton : Button
    {
        private readonly Point r_CellLocation;

        public TicTacToeCellButton(Point i_Location)
        {
            r_CellLocation = i_Location;
            TabStop = false;
        }

        public Point CellLocation
        {
            get
            {
                return r_CellLocation;
            }
        }

        public void SetSymbol(eCellValue i_Symbol)
        {
            Text = i_Symbol != eCellValue.Empty ? i_Symbol.ToString() : string.Empty;
        }
    }
}
