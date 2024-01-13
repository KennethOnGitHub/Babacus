using Babacus;

namespace ExpressionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EvaluateVariableExpressionA_ATrue_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(inputVars, 0);

            bool result = A.Evaluate();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void EvaluateVariableExpressionB_AFalseBTrue_True()
        {
            bool[] inputVars = { false, true };
            VariableExpression B = new VariableExpression(inputVars, 1);

            bool result = B.Evaluate();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateAndExpression_2True_True()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            AndExpression expression = new AndExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());

        }        
        
        [TestMethod]
        public void EvaluateAndExpression_ATrueBFalse_False()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            AndExpression expression = new AndExpression(inputVars, subs);

            Assert.IsFalse(expression.Evaluate());

        }        
        [TestMethod]
        public void EvaluateAndExpression_3Trues_True()
        {
            bool[] inputVars = { true, true, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);
            VariableExpression C = new VariableExpression(inputVars, 2);

            Expression[] subs = { A, B, C };

            AndExpression expression = new AndExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());

        }        
        [TestMethod]
        public void EvaluateAndExpression_2Trues1False_True()
        {
            bool[] inputVars = { true, false, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);
            VariableExpression C = new VariableExpression(inputVars, 2);

            Expression[] subs = { A, B, C };

            AndExpression expression = new AndExpression(inputVars, subs);

            Assert.IsFalse(expression.Evaluate());

        }

        [TestMethod]
        public void EvaluateOrExpression_2Trues_Trues()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            OrExpression expression = new OrExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());

        }        
        [TestMethod]
        public void EvaluateOrExpression_TrueFalse_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            OrExpression expression = new OrExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());

        }
        [TestMethod]
        public void EvaluateOrExpression_2False_False()
        {
            bool[] inputVars = { false, false };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            OrExpression expression = new OrExpression(inputVars, subs);

            Assert.IsFalse(expression.Evaluate());

        }
        [TestMethod]
        public void EvaluateOrExpression_3True_True()
        {
            bool[] inputVars = { true, true, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);
            VariableExpression C = new VariableExpression(inputVars, 2);

            Expression[] subs = { A, B, C };

            OrExpression expression = new OrExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());

        }

        [TestMethod]
        public void EvaluateOrExpression_2True1False_True()
        {
            bool[] inputVars = { true, false, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);
            VariableExpression C = new VariableExpression(inputVars, 2);

            Expression[] subs = { A, B, C };

            OrExpression expression = new OrExpression(inputVars, subs);

            Assert.IsTrue(expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateNotExpression_True_False()
        {
            bool[] inputVars = { true };
            VariableExpression A = new VariableExpression(inputVars, 0);

            NotExpression expression = new NotExpression(inputVars, A);

            bool result = expression.Evaluate();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateNotExpression_False_True()
        {
            bool[] inputVars = { false };
            VariableExpression A = new VariableExpression(inputVars, 0);

            NotExpression expression = new NotExpression(inputVars, A);

            bool result = expression.Evaluate();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateNotExpression_AndExpression2True_False()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            AndExpression andExpression = new AndExpression(inputVars, subs);

            NotExpression expression = new NotExpression(inputVars, andExpression);

            bool result = expression.Evaluate();

            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EvaluateNotExpression_AndExpressionTrueFalse_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(inputVars, 0);
            VariableExpression B = new VariableExpression(inputVars, 1);

            Expression[] subs = { A, B };

            AndExpression andExpression = new AndExpression(inputVars, subs);

            NotExpression expression = new NotExpression(inputVars, andExpression);

            bool result = expression.Evaluate();

            Assert.IsTrue(result);
        }
    }
}