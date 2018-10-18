using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace TicTacToiUI
{
    public partial class FormGameSettings : Form
    {
        private const string k_ComputerName = "Computer";
        private const string k_ErrorMessage = "Player name cannot be empty";

        public FormGameSettings()
        {
            InitializeComponent();
        }

        public string ErrorMessage
        {
            get
            {
                return k_ErrorMessage;
            }
        }

        public string PlayerOneName
        {
            get
            {
                return textBoxPlayer1.Text;
            }
        }

        public string PlayerTwoName
        {
            get
            {
                return textBoxPlayer2.Text;
            }
        }

        public int BoardSize
        {
            get
            {
                return (int)numericUpDownCols.Value;
            }
        }

        public string ComputerName
        {
            get
            {
                return k_ComputerName;
            }
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
        private void checkBoxPlayer2_CheckStateChanged(object sender, EventArgs e)
        {
            if (!textBoxPlayer2.Enabled && checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = string.Empty;
                textBoxPlayer2.BackColor = Color.White;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = ComputerName;
                textBoxPlayer2.BackColor = SystemColors.InactiveCaption;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            bool isValidUserInput;
            eGameMode gameMode;

            isValidUserInput = validateUserInputs();

            if (isValidUserInput)
            {
                gameMode = textBoxPlayer2.Enabled ? eGameMode.MultiPlayer : eGameMode.SingleMode;
                Hide();
                new TicTacToeGameForm(PlayerOneName, PlayerTwoName, BoardSize, gameMode).ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show(ErrorMessage);
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        private bool validateUserInputs()
        {
            return textBoxPlayer1.Text != string.Empty && textBoxPlayer2.Text != string.Empty;
        }

        //// To let the user begin the game simplicity after insert his name.
        private void textBoxPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPlay_Click(sender, e);
            }
        }
    }
}
