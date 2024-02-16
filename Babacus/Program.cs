// See https://aka.ms/new-console-template for more information
using Babacus;
using System;
using System.Collections.Generic;
using System.Globalization;

Console.WriteLine("******************************** \nWELCOME TO BABCUS :3 \nMade by Kenneth Knight \n********************************");

Console.WriteLine("Enter in the boolean algebra expression: ");
string input = Console.ReadLine();

input = Sanitiser.Sanitise(input);

Console.WriteLine(string.Format("Input: {0}", input));

Parser parser = new Parser();
Expression expression = parser.Parse(input);

//a possibility is storing the data on what variables are in it in the expression itself. This can allow for a smaller inputVariables
//parameter since you don't need to send the value for all 26 letters
char[] variablesInInput = input.Where(x => char.IsLetter(x)).Distinct().ToArray();
Array.Sort(variablesInInput);

int[] variableIndexes = variablesInInput.Select(x => x - 'A').ToArray(); 

Console.WriteLine(" " + string.Join(" | ", variablesInInput) + " | Output");

ulong possibleCombinations = (ulong)Math.Pow(2.0, (double)variablesInInput.Length);
for (ulong inputInBinary = 0; inputInBinary < possibleCombinations; inputInBinary++)
{
    const int ulongLen = 64;

    const int possibleVariables = 26 * 2;
    bool[] inputVariables = new bool[possibleVariables];

    int start = ulongLen - variablesInInput.Length;
    for (int digitIndex = start; digitIndex < ulongLen; digitIndex++)
    {
        ulong digitValue = (inputInBinary >> (ulongLen - 1 - digitIndex)) & 1; //change to int?

        if (digitValue == 1)
        {
            int positionInInputVariables = variableIndexes[digitIndex - start];

            inputVariables[positionInInputVariables] = true;

        }
    }



    Console.WriteLine(" " + string.Join(" | ", variablesInInput) + $"{expression.Evaluate(inputVariables)}");
}




//





//TODO: make sure lowercase and uppercase are treated as diff variables

//create an input array
//express it in results
//store results in 2d array




