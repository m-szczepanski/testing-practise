using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests
{
    public class BmiDeterminatorTests
    {
        [Theory]
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(15.0, BmiClassification.Underweight)]
        [InlineData(19.9, BmiClassification.Normal)]
        [InlineData(26.0, BmiClassification.Overweight)]
        [InlineData(31.0, BmiClassification.Obesity)]
        [InlineData(35.0, BmiClassification.ExtremeObesity)]
        public void DetermineBmi_ForBmiBellow18_5_ReturnsUnderweightClassification(double bmi, BmiClassification classification)
        {
            BmiDeterminator bmiDeterminator = new BmiDeterminator();

            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            Assert.Equal(classification, result);
        }

        
    }
}
