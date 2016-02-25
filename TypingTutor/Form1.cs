using System;
using System.Drawing;
using System.Windows.Forms;

namespace TypingTutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label[] _keys;
        private Compliments _compliments;
        private Condolences _condolences;

        private void Form1_Load(object sender, EventArgs e)
        {
            _logic = new GameLogic(this);
            _compliments = new Compliments();
            _condolences = new Condolences();
            _keys = new Label[26];

            for (int i = 0; i < 26; i++)
            {
                // Create new label
                var letter = new Label
                {
                    Anchor = AnchorStyles.None,
                    AutoSize = true,
                    Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    Name = "label" + Tools.OrdinalValueToLetter(i),
                    Size = new Size(42, 40),
                    TabIndex = i,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = Tools.OrdinalValueToLetter(i).ToString()
                };

                // Set label properties

                _keys[i] = letter;
            }

            // Layout the controls in the shape of a keyboard
            int hCharSpacing = 30;
            int vCharSpacing = 30;

            int yValueFirstRow = 150;
            int yValueSecondRow = yValueFirstRow + vCharSpacing;
            int yValueThirdRow = yValueFirstRow + vCharSpacing * 2;

            int xStartValueFirstRow = 67;
            int xStartValueSecondRow = 67 + hCharSpacing / 2;
            int xStartValueThirdRow = 67 + hCharSpacing;

            _keys[Tools.LetterToOrdinalValue('Q')].Location = new Point(xStartValueFirstRow + hCharSpacing * 0, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('W')].Location = new Point(xStartValueFirstRow + hCharSpacing * 1, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('E')].Location = new Point(xStartValueFirstRow + hCharSpacing * 2, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('R')].Location = new Point(xStartValueFirstRow + hCharSpacing * 3, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('T')].Location = new Point(xStartValueFirstRow + hCharSpacing * 4, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('Y')].Location = new Point(xStartValueFirstRow + hCharSpacing * 5, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('U')].Location = new Point(xStartValueFirstRow + hCharSpacing * 6, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('I')].Location = new Point(xStartValueFirstRow + hCharSpacing * 7, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('O')].Location = new Point(xStartValueFirstRow + hCharSpacing * 8, yValueFirstRow);
            _keys[Tools.LetterToOrdinalValue('P')].Location = new Point(xStartValueFirstRow + hCharSpacing * 9, yValueFirstRow);

            _keys[Tools.LetterToOrdinalValue('A')].Location = new Point(xStartValueSecondRow + hCharSpacing * 0, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('S')].Location = new Point(xStartValueSecondRow + hCharSpacing * 1, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('D')].Location = new Point(xStartValueSecondRow + hCharSpacing * 2, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('F')].Location = new Point(xStartValueSecondRow + hCharSpacing * 3, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('G')].Location = new Point(xStartValueSecondRow + hCharSpacing * 4, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('H')].Location = new Point(xStartValueSecondRow + hCharSpacing * 5, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('J')].Location = new Point(xStartValueSecondRow + hCharSpacing * 6, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('K')].Location = new Point(xStartValueSecondRow + hCharSpacing * 7, yValueSecondRow);
            _keys[Tools.LetterToOrdinalValue('L')].Location = new Point(xStartValueSecondRow + hCharSpacing * 8, yValueSecondRow);

            _keys[Tools.LetterToOrdinalValue('Z')].Location = new Point(xStartValueThirdRow + hCharSpacing * 0, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('X')].Location = new Point(xStartValueThirdRow + hCharSpacing * 1, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('C')].Location = new Point(xStartValueThirdRow + hCharSpacing * 2, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('V')].Location = new Point(xStartValueThirdRow + hCharSpacing * 3, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('B')].Location = new Point(xStartValueThirdRow + hCharSpacing * 4, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('N')].Location = new Point(xStartValueThirdRow + hCharSpacing * 5, yValueThirdRow);
            _keys[Tools.LetterToOrdinalValue('M')].Location = new Point(xStartValueThirdRow + hCharSpacing * 6, yValueThirdRow);

            for (int i = 0; i < 26; i++)
            {
                Controls.Add(_keys[i]);
            }

            _logic.RunGameLoop();
        }

        private GameLogic _logic;
        readonly Color _backColor = Color.Bisque;
        readonly Color _highlightedColor = Color.LightGreen;

        public void SelectKey(char keyToSelect)
        {
            _keys[Tools.LetterToOrdinalValue(keyToSelect)].BackColor = _highlightedColor;
        }

        public void UnselectKey(char keyToUnselect)
        {
            _keys[Tools.LetterToOrdinalValue(keyToUnselect)].BackColor = _backColor;
        }

        public void SetResponseText(string text)
        {
            label1.Text = text;
        }

        public bool IsHighlighted(char key)
        {
            if (_keys[Tools.LetterToOrdinalValue(key)].BackColor == _highlightedColor)
                return true;
            else
                return false;
        }
    }
}
