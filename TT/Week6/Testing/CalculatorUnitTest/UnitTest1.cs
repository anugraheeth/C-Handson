using CalcluatorLibrary;
namespace CalculatorUnitTest
{
    public class Tests
    {
        private CalcluatorLibrary.Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new CalcluatorLibrary.Calculator();
        }

        [Test]
        public void AddUnitTest()
        {
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void SubtractUnitTest()
        {
            int result = calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MultiplyUnitTest()
        {
            int result = calculator.Multiply(2, 3);
            Assert.AreEqual(6, result);
        }
    }
}