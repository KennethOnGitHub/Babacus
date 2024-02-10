// See https://aka.ms/new-console-template for more information
using Babacus;
using System;

Console.WriteLine("******************************** \nWELCOME TO BABCUS :3 \nMade by Kenneth Knight \n********************************");

Console.WriteLine("Enter in the boolean algebra expression: ");
string input = Console.ReadLine();

input = Sanitiser.Sanitise(input);

Console.WriteLine(string.Format("Input: {0}", input));

Parser parser = new Parser();
Expression expression = parser.Parse(input);



