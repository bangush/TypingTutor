using System;
using System.Collections;
using System.Linq;

namespace TypingTutor
{
    internal class GameLogic
    {
        private readonly Form1 _parent;


        // I'll create an array of letters based upon percentages such that the 
        private LetterTable _letterTable;
        private Tools _tools;
        private Condolences _condolences;
        private Compliments _compliments;
        private LevelData _levelData;

        public GameLogic(Form1 parent)
        {
            _parent = parent;
            _parent.KeyPress += _parent_KeyPress;
            _condolences = new Condolences();
            _compliments = new Compliments();
            _tools = new Tools();
            // Start at the first level
            _levelNumber = 0;

            int[] rates = new int[26];
            rates[Tools.LetterToOrdinalValue('A')] = 25;
            rates[Tools.LetterToOrdinalValue('s')] = 25;
            rates[Tools.LetterToOrdinalValue('d')] = 25;
            rates[Tools.LetterToOrdinalValue('f')] = 25;

            _letterTable = new LetterTable(rates);
        }

        private void _parent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // If the key back color is highlighted (IE, press was correct)
            if (_parent.IsHighlighted(e.KeyChar))
            {
                _levelData.NumLettersDone++;
                _parent.UnselectKey(e.KeyChar);
                if (_levelData.NumLettersInLevel >= _levelData.NumLettersDone)
                {
                    _parent.SetResponseText(_compliments.GetCompliment());
                    SelectNextLetter();
                }
                else
                {
                    _parent.SetResponseText("Done!");
                }
            }
            // Otherwise press was wrong
            else
            {
                _parent.SetResponseText(_condolences.GetCondolence());
            }
        }

        private int _levelNumber;
        private int _maxLevelNumber;

        public void RunGameLoop()
        {


            if (_levelNumber < _maxLevelNumber)
            {
                //Configure a single level of the game
                _levelData = new LevelData();
                // Probably load a set of parameters from a text config file?

                // Run a level of the game
                RunLevel(_levelData);
            }
        }

        private void RunLevel(LevelData singleLevelData)
        {
                SelectNextLetter();
        }

        // Sets the highlighted key in the parent form.  
        // Additionally, should handle any other logic for tracking the number of letters, etc...
        private void SelectNextLetter()
        {
            _parent.SelectKey(Tools.OrdinalValueToLetter(_letterTable.SelectNextOrdinal()));
        }
    }
}
