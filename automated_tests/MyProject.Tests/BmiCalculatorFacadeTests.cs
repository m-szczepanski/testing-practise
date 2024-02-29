using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTests
    {
        public BmiCalculatorFacadeTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
        private readonly ITestOutputHelper _outputHelper;

        [Theory]
        [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
        public void GetResult_ForValidInputs_ReturnsCorrectSummary(BmiClassification bmiClassification, string expectedResult)
        {
            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();

            bmiDeterminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);

            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);

            BmiResult result = bmiCalculatorFacade.GetResult(1, 1);
            _outputHelper.WriteLine($"For classification {bmiClassification} the result is: {result.Summary}.");
            

            result.Summary.Should().Be(expectedResult);
        }
    }
}
