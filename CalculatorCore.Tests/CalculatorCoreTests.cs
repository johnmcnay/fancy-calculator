using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        private Calculator _calc;

        [TestInitialize]
        public void TestSetup()
        {
            _calc = new Calculator();
        }
        
        [TestMethod]
        public void AddTwoNumbers()
        {
            EvaluationResult result = _calc.Evaluate("6 + 8");
            Assert.AreEqual(14m, result.Result);
        }

        [TestMethod]
        public void ValidFirstOperand()
        {
            EvaluationResult result = _calc.Evaluate("one + 2");
            Assert.AreEqual("The first number, 'one', was not a valid number.", result.ErrorMessage);
        }

        [TestMethod]
        public void ValidSecondOperand()
        {
            EvaluationResult result = _calc.Evaluate("1 + bob");
            Assert.AreEqual("The second number, 'bob', was not a valid number.", result.ErrorMessage);

        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            EvaluationResult result = _calc.Evaluate("6 - 2");
            Assert.AreEqual(4m, result.Result);

            result = _calc.Evaluate("2 - 6");
            Assert.AreEqual(-4m, result.Result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            EvaluationResult result = _calc.Evaluate("5 * 7");
            Assert.AreEqual(35m, result.Result);
        }


        [TestMethod]
        public void DivideTwoNumbers()
        {
            EvaluationResult result = _calc.Evaluate("36 / 4");
            Assert.AreEqual(9m, result.Result);
        }

        [TestMethod]
        public void ValidOperatorCheck()
        {
            EvaluationResult result = _calc.Evaluate("8 plus 4");
            Assert.AreEqual("The operator 'plus' is not valid. Must use + - * /", result.ErrorMessage);
        }

        [TestMethod]
        public void ValidExpressionInAcceptableNumberOfParts()
        {
            EvaluationResult result = _calc.Evaluate("8 +");
            Assert.AreEqual("The operation must be in the form '5 + 8' or '+ 8'. Please try again.", result.ErrorMessage);
        }

        [TestMethod]
        public void ContinuationInput()
        {
            EvaluationResult result = _calc.Evaluate("+ 7");
            Assert.AreEqual(7m, result.Result);
            result = _calc.Evaluate("+ 9");
            Assert.AreEqual(16m, result.Result);
            result = _calc.Evaluate("3 + 1");
            Assert.AreEqual(4m, result.Result);
            result = _calc.Evaluate("- 9");
            Assert.AreEqual(-5m, result.Result);
        }

        [TestMethod]
        public void isAnOperatorCheck()
        {
            Assert.IsTrue("+".isOperator());
            Assert.IsTrue("-".isOperator());
            Assert.IsTrue("/".isOperator());
            Assert.IsTrue("*".isOperator());

            Assert.IsFalse("plus".isOperator());
        }
    }
}
