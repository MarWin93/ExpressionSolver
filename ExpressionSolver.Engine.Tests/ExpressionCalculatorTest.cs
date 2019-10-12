using NUnit.Framework;
using System;

namespace EquationsSolver.Engine.Tests
{

    [TestFixture]
    public class ExpressionCalculatorTest
    {
        private ExpressionCalculator subject;

        [SetUp]
        public void SetUp()
        {
            subject = new ExpressionCalculator();
        }

        [TestCaseSource(nameof(GetValidCalculateExamples))]
        public void Calculate(string input, decimal expectedResult)
        {
            var result = subject.Calculate(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Calculate_Throws_ArgumentException_When_Input_Is_Null_Or_Empty([Values(null, "")] string input)
        {
            const string expectedExceptionMessage = "Given expression cannot be null or empty.";

            Assert.Throws<ArgumentException>(() => subject.Calculate(input), expectedExceptionMessage);
        }

        [TestCase("2 ^ 2", "^")]
        [TestCase("var1 + 2", "var1")]
        public void Calculate_Throws_ArgumentException_When_Unsupported_Expression_Element_Occured(
            string input,
            string invalidEquationElement)
        {
            var expectedExceptionMessage = $"Expression contains invalid element:'{invalidEquationElement}'";

            Assert.Throws<ArgumentException>(() => subject.Calculate(input), expectedExceptionMessage);
        }

        [Test]
        public void Calculate_Throws_ArgumentException_When_Divide_By_Zero_Occured()
        {
            const string input = "2 + 2 - 3 / 0";
            const string expectedExceptionMessage = "Given expression contains division by 0.";

            Assert.Throws<ArgumentException>(() => subject.Calculate(input), expectedExceptionMessage);
        }

        private static readonly object[] GetValidCalculateExamples =
        {
            new object[] {"1 * 2 + 3 * 4", 14m },
            new object[] {"1 + 2 * 3 + 4", 11m },
            new object[] {"1 + 2 + 3 + 4", 10m },
            new object[] {"4 + 5 * 2", 14m },
            new object[] {"4 + 5 / 2", 6.5m },
            new object[] {"4 + 5 / 2 - 1", 5.5m },
            new object[] {"335 + 25 / 25 - 5", 331m },
            new object[] {"4 - 5", -1m },
            new object[] {"5", 5m }
        };
    }
}