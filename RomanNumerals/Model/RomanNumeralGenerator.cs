using System;

namespace RomanNumerals
{
    // Created Class RomanNumeralGenerator that implements IRomanNumeralGenerator
    public class RomanNumeralGenerator : IRomanNumeralGenerator
    {
        // I decided to go for recursive solution since we have defined specific range from 1 to 3999
        // If the method should work for larger numbers I would consider using a for loop so that program doesn't run out of memory
        public string Generate(int number)
        {
            // First we must check if the number is in range
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            // Then i recursively translate left most digit to roman numeral
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + Generate(number - 1000);
            if (number >= 900) return "CM" + Generate(number - 900);
            if (number >= 500) return "D" + Generate(number - 500);
            if (number >= 400) return "CD" + Generate(number - 400);
            if (number >= 100) return "C" + Generate(number - 100);
            if (number >= 90) return "XC" + Generate(number - 90);
            if (number >= 50) return "L" + Generate(number - 50);
            if (number >= 40) return "XL" + Generate(number - 40);
            if (number >= 10) return "X" + Generate(number - 10);
            if (number >= 9) return "IX" + Generate(number - 9);
            if (number >= 5) return "V" + Generate(number - 5);
            if (number >= 4) return "IV" + Generate(number - 4);
            if (number >= 1) return "I" + Generate(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }    
}
