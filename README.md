# Amount to Words Converter

A user should be able to enter a number less than 2 billion with exactly 2 decimal places with nothing but numbers and a decimal point (no commas).

Upon clicking the “Convert” button the program will fill the memo with the English words that express that number as a string of words (dollars and cents). The program should encode words exactly as you would say them in English when reading out the monetary amount.

Example 1:
If the user enters 1357256.32 then the program would convert that to “one million, three hundred and fifty seven thousand, two hundred and fifty six DOLLARS AND thirty two CENTS”.

Example 2:
If the user enters 1.01 then the program would convert that to “one DOLLAR AND one CENT”.

Example 3:
If the user enters 102030405.06 then the program would convert that to “one hundred and two million, thirty thousand, four hundred and five DOLLARS AND six CENTS”.

Example 4:
If the user enters 1000000000.99 then the program would convert that to “one billion DOLLARS AND ninety nine CENTS”.

Hints:
No validation of input is required: the test assumes the user will type numbers without commas and within the limits of this program’s requirements (less than 2 billion and with exactly 2 decimal places always)

Any number less than 2 billion should be allowed but in fact it's easy once correctly solved that trillions be also added –extending to trillions is not required, this is a hint only.

The solution could be done in a number of ways but needs to be elegant.

Loops or recursion are often seen in the solution - one of these is possibly smaller in size. Smaller/more elegant is better.

It is important to note the way we comma separate numbers eg 1,357,256.32 as this represents the 1000 divisor (billion, million, thousand etc) and the pause in the English spoken numbers. Note the commas are not in the text input

You may assume that the text has at least one integer to the left hand side of the '.' and that the right hand side is exactly 2 decimal places. You should code a function or functions that accept INT and return a string by calling it twice something like this: - Words = Int2Words(leftInt) + “DOLLARS AND ”  + Int2Words(rightInt) + “ CENTS”.

Zero should work as an input on either or both sides of the decimal.

There are language rules in English regarding speaking words that are not obvious and hard to discover. You should use a range of test numbers from small to large and check them against how you would say them in common speech.