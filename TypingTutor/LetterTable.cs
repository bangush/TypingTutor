using System;
using System.Collections;
using System.Linq;

namespace TypingTutor
{
    class LetterTable
    {
        private Random _random;
        private int[] _letterTable;
        
        public LetterTable(int[] characterRates)
        {
            _random = new Random();
            
            // Verify we have the right amount of data
            if (characterRates.Length != 26)
                throw new IndexOutOfRangeException();

            // Ensure the rate data adds to 100%
            int counter = 0;
            for (int i = 0; i < 26; i++)
            {
                counter += characterRates[i];
            }

            if (counter != 100)
                throw new ArgumentOutOfRangeException();
            ArrayList al = new ArrayList();

            for (int i = 0; i < 26; i++)
            {
                int characterRate = characterRates[i];
                for (int j = 0; j < characterRate; j++)
                {
                    al.Add(i);
                }
            }


            _letterTable = al.Cast<int>().ToArray();

        }

        public int SelectNextOrdinal()
        {
            // Pick key to press
            
            int key = _random.Next(0, 99);
            return _letterTable[key];
        }
    }
}
