# RomanNumerals

This is my implementation of the following interface:

``` C#
public interface IRomanNumeralGenerator {
string Generate(int number);
}
```

It is used to create [Roman Numerals](https://en.wikipedia.org/wiki/Roman_numerals) from Arabic numbers.

## Implementation
My solution is written in C# using .NET framework. I decided to go for recursive approach:

``` C#
        public string Generate(int number)
        {
            // First we must check if the number is in range
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value between 1 and 3999");
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
```

## MVVM 
To show off my skills, I created simple GUI for this app using MVVM pattern. MVVM stands for Model, View, ViewModel and it can be used to separate the logic from the UI:

![MVVM Pattern](https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/MVVMPattern.png/500px-MVVMPattern.png)

As we can see from this scheme (wikipedia), View is separated from Model by ViewModel that uses bindings for data. We can easily create different View, for example, for mobile app and use these same bindings.

## Testing
I created NUnit Test project for unit testing. In this project I used 6 unit tests:
- input: 1; expected output: "I"
- input: 2; expected output: "II"
- input: 5; expected output: "V"
- input: 10; expected output: "X"
- input: 20; expected output: "XX"
- input: 3999; expected output: "MMMCMXCIX"

All tests passed before every commit
