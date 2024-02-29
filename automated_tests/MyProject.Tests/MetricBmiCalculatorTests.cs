using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTests
    {
        public static IEnumerable<object[]> GetSampleData()
        {
            yield return new object[] { 100, 170, 34.6 };
            yield return new object[] { 57, 170, 19.72 };
            yield return new object[] { 70, 170, 24.22 };
            yield return new object[] { 77, 160, 30.08 };
            yield return new object[] { 80, 190, 22.16 };
            yield return new object[] { 90, 190, 24.93 };
        }

        [Theory]
        [MemberData(nameof(GetSampleData))]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            double result = calculator.CalculateBmi(weight, height);

            Assert.Equal(bmiResult, result);
        }

        [Theory]
        [JsonFileData("Data/MetricBmiCalculatorData.json")]
        public void Calculate_BmiForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            Action action = () => calculator.CalculateBmi(weight,height);

            Assert.Throws<ArgumentException>(action);
        }
    }
}
