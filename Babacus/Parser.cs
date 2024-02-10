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

        public Expression Parse(string input)
        {
            return ParseExpression(input);
        }
        
        public Expression ParseExpression(string input)
        {
            Expression left = ParseTerm(input);

            parserHead++;

            if (parserHead >= input.Length)
            {
                return left;
            }

            if (input[parserHead] == '|')
            {
                Expression right = ParseExpression(input);

                return new OrExpression( left, right );
            }

            parserHead--;
            return left;

        }

        public Expression ParseTerm(string input)
        {
            Expression left = ParseFactor(input);

            parserHead++;

            if (parserHead >= input.Length)
            {
                return left;
            }

            if (input[parserHead] == '&')
            {
                Expression right = ParseTerm(input);

                return new AndExpression( left, right );
                
            }

            parserHead--;
            return left;

        }

        public Expression ParseFactor(string input)
        {
            parserHead++;
            if (input[parserHead] == '¬')
            {
                return new NotExpression(ParseFactor(input));
            }

            if (Char.IsLetter(input[parserHead]) == true)
            {
                return new VariableExpression(input[parserHead] - 'A');
            }

            if (input[parserHead] == '0' || input[parserHead] == '1')
            {
                return new Constant(input[parserHead] == '1');
            }
            
            if (input[parserHead] == '(')
            {
                Expression bracketedExpression = ParseExpression(input);
                parserHead++;
                if (input[parserHead] ==  ')')
                {
                    return new BracketedExpression(bracketedExpression);
                }else
                {
                    throw new Exception("Yo u got ur brackets wrong g");
                }
            }

            throw new Exception("Invalid text!!!!! :333 Empty Factor!");

            

        }
    }
}
