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
        public bool[] inputVariables;
        public Expression(bool[] inputVars)
        {
            inputVariables = inputVars;
        }

        public abstract bool Evaluate();

    }

    public abstract class SingleExpression : Expression {
        public SingleExpression(bool[] inputVars) : base(inputVars) { }
    }

    public class NotExpression : SingleExpression
    {
        Expression subexpression;
        public NotExpression(bool[] inputVars, Expression sub) : base(inputVars)
        {
            this.subexpression = sub;
        }

        public override bool Evaluate()
        {
            return !subexpression.Evaluate();
        }
    }

    public class VariableExpression : SingleExpression
    {
        int varIndex;
        public VariableExpression(bool[] inputVars, int varIndex) : base(inputVars)
        {
            this.varIndex = varIndex;
        }

        public override bool Evaluate()
        {
            return inputVariables[varIndex];
        }
    }


    public abstract class CompositeExpression : Expression
    {

        protected Expression[] subexpressions;
        public CompositeExpression(bool[] inputVars, Expression[] subs) : base(inputVars)
        {
            subexpressions = subs;
        }
    }
    public class OrExpression : CompositeExpression
    {
        public OrExpression(bool[] inputVars, Expression[] subs) : base(inputVars, subs)
        {
        }

        public override bool Evaluate()
        {
            foreach (Expression expression in subexpressions)
            {
                if (expression.Evaluate())
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class AndExpression : CompositeExpression
    {
        public AndExpression(bool[] inputVars, Expression[] subs) : base(inputVars, subs) { }
        public override bool Evaluate()
        {
            foreach (Expression expression in subexpressions)
            {
                if (!expression.Evaluate())
                {
                    return false;
                }
            }
            return true;
        }
    }


}
