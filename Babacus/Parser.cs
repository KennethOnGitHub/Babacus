using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Babacus
{
    public class Parser
    {
        int parserHead = -1;
        string input;

        public Parser(string input ) //having this be a parameter set when it is instantiated feels kinda bad ngl, maybe make a singe parse method where you pass in the input as a param or maybe go in on the recursive approach?
        {
            this.input = input;
        }
        
        public Expression ParseExpression()
        {
            parserHead++;

            Expression left = ParseTerm();

            parserHead++;
            if (input[parserHead] == '|')
            {
                Expression right = ParseExpression();

                return new OrExpression( left, right );
            }

            return left;

        }

        public Expression ParseTerm()
        {
            Expression left = ParseFactor();

            parserHead++;

            if (parserHead >= input.Length)
            {
                return left;
            }

            if (input[parserHead] == '&')
            {
                Expression right = ParseTerm();
                
            }

        }

        public Expression ParseFactor()
        {
            parserHead++;
            if (this.input[parserHead] == '¬')
            {
                return new NotExpression(ParseFactor());
            }

            if (Char.IsLetter(this.input[parserHead]) == true)
            {
                return new VariableExpression(this.input[parserHead] - 'A');
            }

            if (this.input[parserHead] == '0' || this.input[parserHead] == '1')
            {
                return new Constant(input[parserHead] == '1');
            }
            /*
            if (this.input[parserHead] == '(')
            {
                Expression bracketedExpression = ParseExpression();
                parserHead++;
                if (input[parserHead] ==  ')')
                {
                    return bracketedExpression;
                }else
                {
                    throw new Exception("Yo u got ur brackets wrong g");
                }
            }*/

            throw new Exception("Invalid text!!!!! :333 Empty Factor!");

            

        }
    }
}
