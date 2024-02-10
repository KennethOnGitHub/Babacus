using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Babacus
{
    public abstract class Expression
    {
        public Expression()
        {
        }

        public abstract bool Evaluate(bool[] inputvars);

        public abstract string getStringRepresentation(); //ovveride tostring instead!

    }

    public abstract class SingleExpression : Expression {
        public SingleExpression() : base() { }
    }

    public class BracketedExpression : SingleExpression
    {
        Expression subexpression;
        public BracketedExpression(Expression sub) : base()
        {
            this.subexpression = sub;
        }

        public override bool Evaluate(bool[] inputvars)
        {
            return subexpression.Evaluate(inputvars);
        }

        public override string getStringRepresentation()
        {
            return string.Format("({0})", subexpression.getStringRepresentation());
        }

    }

    public class NotExpression : SingleExpression
    {
        Expression subexpression;
        public NotExpression(Expression sub) : base()
        {
            this.subexpression = sub;
        }

        public override bool Evaluate(bool[] inputvars)
        {
            return !subexpression.Evaluate(inputvars);
        }

        public override string getStringRepresentation()
        {
            string output = string.Format("¬{0}", subexpression.getStringRepresentation());
            return output;
        }
    }

    public class VariableExpression : SingleExpression
    {
        int varIndex;
        public VariableExpression(int varIndex) : base()
        {
            this.varIndex = varIndex;
        }

        public override bool Evaluate(bool[] inputvars)
        {
            return inputvars[varIndex];
        }

        public override string getStringRepresentation()
        {
            char letter = (char)('A' + varIndex);

            return letter.ToString();
        }
    }

    public class Constant : SingleExpression
    {
        bool val;
        public Constant(bool val) : base() 
        {
            this.val = val;   
        }

        public override bool Evaluate(bool[] inputvars)
        {
            return this.val;
        }

        public override string getStringRepresentation()
        {
            return this.val ? "1" : "0";
        }
    }




    public abstract class CompositeExpression : Expression
    {
        protected Expression leftExpression;
        protected Expression rightExpression;

        public CompositeExpression(Expression left, Expression right) : base()
        {
            this.leftExpression = left;
            this.rightExpression = right;

        }
    }
    public class OrExpression : CompositeExpression
    {
        public OrExpression(Expression left, Expression right) : base(left, right) { }

        public override bool Evaluate(bool[] inputvars)
        {
            return leftExpression.Evaluate(inputvars) || rightExpression.Evaluate(inputvars);
        }

        public override string getStringRepresentation()
        {
            string output = string.Format("{0} | {1}", leftExpression.getStringRepresentation(), rightExpression.getStringRepresentation());
            return output;
        }
    }

    public class AndExpression : CompositeExpression
    {
        public AndExpression(Expression left, Expression right) : base(left, right) { }
        public override bool Evaluate(bool[] inputvars)
        {
            return leftExpression.Evaluate(inputvars) && rightExpression.Evaluate(inputvars);
        }
        public override string getStringRepresentation()
        {
            string output = string.Format("{0} & {1}", leftExpression.getStringRepresentation(), rightExpression.getStringRepresentation());
            return output;
        }


    }


}
