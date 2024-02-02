using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Babacus
{
    internal class Parser
    {
        int parserHead = 0;
        string input;

        public Parser(string input ) 
        {
            this.input = input;
        }

        public Expression ParseExpression()
        {
            while (parserHead < input.Length)
            {
                Expression left = ParseTerm();

            }
        }

        public Expression ParseTerm()
        {
            while (parserHead < input.Length)
            {

            }

        }

        public Expression ParseFactor()
        {
            while (parserHead < input.Length)
            {
                if (this.input[parserHead] == '(')
                {
                    if (input[parserHead] ==  ')')
                    {
                        parserHead++;
                        return ParseExpression();
                    }else
                    {
                        throw new Exception("Yo u got ur brackets wrong g");
                    }
                }

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

                throw new Exception("Invalid text!!!!! :333");

            }

        }
    }
}
