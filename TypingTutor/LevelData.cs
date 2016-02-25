using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTutor
{
    internal class LevelData
    {
        public int NumLettersInLevel { get; }
        public int NumLettersDone { get; set; }

        public LevelData()
        {
            NumLettersDone = 0;
            NumLettersInLevel = 10;
        }
    }
}
