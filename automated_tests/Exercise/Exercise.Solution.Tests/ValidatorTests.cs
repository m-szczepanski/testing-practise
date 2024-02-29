using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class ValidatorTests
    {
        private List<List<DateRange>> _dateRanges = new List<List<DateRange>>
        {
            new List<DateRange>()
            {
                new DateRange(new DateTime(2020, 1, 1), new DateTime(2020, 1, 15)),
                new DateRange(new DateTime(2020, 2, 1), new DateTime(2020, 2, 15)),
            },
            new List<DateRange>()
            {
                new DateRange(new DateTime(2020, 1, 15), new DateTime(2020, 1, 25)),
            },
            new List<DateRange>()
            {
                new DateRange(new DateTime(2020, 1, 8), new DateTime(2020, 1, 25)),
            },
            new List<DateRange>()
            {
                new DateRange(new DateTime(2020, 1, 12), new DateTime(2020, 1, 14)),
            }
        };

        [Theory]
        [ClassData(typeof(ValidatorTestsData))]
        public void ValidateOverlaping_ForOverlapingDateRanges_ReturnFlase(List<DateRange> ranges)
        {

            DateRange input = new DateRange(new DateTime(2020, 1, 10), new DateTime(2020, 1, 20));
            Validator validator = new Validator();

            bool result = validator.ValidateOverlapping(ranges, input);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void ValidateOverlaping_ForNoneOverlapingDateRanges_ReturnTrue(int index)
        {
            List<DateRange> ranges = _dateRanges[index];

            DateRange input = new DateRange(new DateTime(2020, 1, 10), new DateTime(2020, 1, 20));
            Validator validator = new Validator();

            bool result = validator.ValidateOverlapping(ranges, input);

            result.Should().BeFalse();
        }
    }
}
