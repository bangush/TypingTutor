using System;
using TypingTutor.Properties;

namespace TypingTutor
{
    public class Tools
    {
        // Given the ordinal Value of a character, 0-25 inclusive, returns the corresponding letter of the alphabet.
        // 0 = A
        // 1 = B
        // etc...
        public static char OrdinalValueToLetter(int ordinalValue)
        {
            if (ordinalValue > 25 || ordinalValue < 0)
                throw new ArgumentOutOfRangeException(nameof(ordinalValue), ordinalValue, Resources.Tools_OrdinalValueToLetter_Parameter_must_be_between_0_and_25);

            var letter = (char) (ordinalValue + 65);
            return letter;
        }

        public static int LetterToOrdinalValue(char letter)
        {
            if (!char.IsLetter(letter))
                throw new ArgumentOutOfRangeException(nameof(letter), letter,
                    Resources.Tools_LetterToOrdinalValue_Parameter_must_be_a_letter_as_defined_by_Char_IsLetter___);

            int ordinalValue = char.ToUpper(letter);
            return ordinalValue - 65;
        }
    }
}