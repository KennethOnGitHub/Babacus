using Babacus;

namespace ExpressionTests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void EvaluateVariableExpressionA_ATrue_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(0);

            bool result = A.Evaluate(inputVars);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void EvaluateVariableExpressionB_AFalseBTrue_True()
        {
            bool[] inputVars = { false, true };
            VariableExpression B = new VariableExpression(1);

            bool result = B.Evaluate(inputVars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateAndExpression_2True_True()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            AndExpression expression = new AndExpression(A, B);

            Assert.IsTrue(expression.Evaluate(inputVars));

        }        
        
        [TestMethod]
        public void EvaluateAndExpression_ATrueBFalse_False()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            AndExpression expression = new AndExpression(A, B);

            Assert.IsFalse(expression.Evaluate(inputVars));

        }        
       

        [TestMethod]
        public void EvaluateOrExpression_2Trues_Trues()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            OrExpression expression = new OrExpression(A, B);

            Assert.IsTrue(expression.Evaluate(inputVars));

        }        
        [TestMethod]
        public void EvaluateOrExpression_TrueFalse_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            OrExpression expression = new OrExpression(A, B);

            Assert.IsTrue(expression.Evaluate(inputVars));

        }
        [TestMethod]
        public void EvaluateOrExpression_2False_False()
        {
            bool[] inputVars = { false, false };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            OrExpression expression = new OrExpression(A, B);

            Assert.IsFalse(expression.Evaluate(inputVars));

        }
        

        [TestMethod]
        public void EvaluateNotExpression_True_False()
        {
            bool[] inputVars = { true };
            VariableExpression A = new VariableExpression(0);

            NotExpression expression = new NotExpression(A);

            bool result = expression.Evaluate(inputVars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateNotExpression_False_True()
        {
            bool[] inputVars = { false };
            VariableExpression A = new VariableExpression(0);

            NotExpression expression = new NotExpression(A);

            bool result = expression.Evaluate(inputVars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateNotExpression_AndExpression2True_False()
        {
            bool[] inputVars = { true, true };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);

            AndExpression andExpression = new AndExpression(A, B);

            NotExpression expression = new NotExpression(andExpression);

            bool result = expression.Evaluate(inputVars);

            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void EvaluateNotExpression_AndExpressionTrueFalse_True()
        {
            bool[] inputVars = { true, false };
            VariableExpression A = new VariableExpression(0);
            VariableExpression B = new VariableExpression(1);


            AndExpression andExpression = new AndExpression(A, B);

            NotExpression expression = new NotExpression(andExpression);

            bool result = expression.Evaluate(inputVars);

            Assert.IsTrue(result);
        }
    }

    [TestClass] //i would put these in a different file but idk if that'll work
    public class PrintTests
    {
        
        [TestMethod]
        public void ParseFactor_Variable_VariableExpression()
        {
            Parser parser = new Parser("A");

            Expression expression = parser.ParseFactor();
            string result = expression.getStringRepresentation();

            Assert.AreEqual("A", result);

        }

        [TestMethod]
        public void ParseFactor_B_BVariableExpression()
        {
            Parser parser = new Parser("B");

            Expression expression = parser.ParseFactor();
            string result = expression.getStringRepresentation();

            Assert.AreEqual("B", result);

        }

        [TestMethod]
        public void ParseFactor_NotB_NotBExpression()
        {
            Parser parser = new Parser("¬B");

            Expression expression = parser.ParseFactor();
            string result = expression.getStringRepresentation();

            Assert.AreEqual("¬B", result);
        }

        [TestMethod]
        public void ParseFactor_1_ConstExpression1()
        {
            Parser parser = new Parser("1");

            Expression expression = parser.ParseFactor();
            string result = expression.getStringRepresentation();

            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void ParseFactor_0_ConstExpression0()
        {
            Parser parser = new Parser("0");

            Expression expression = parser.ParseFactor();
            string result = expression.getStringRepresentation();

            Assert.AreEqual("0", result);
        }
    }
}