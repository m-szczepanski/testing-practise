﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class ListHelperTests
    {
        [Fact]
        public void FilterOddNumber_ForListOfNumbers_ReturnEveryOddNumber()
        {
            List<int> input = new List<int>() { 1, 2, 2, 3, 5, 7, 9, 8, 2};

            List<int> expected = new List<int>() { 1, 3, 5, 7, 9 };

            List<int> result = ListHelper.FilterOddNumber(input);

            result.Should().Equal(expected);
        }
    }
}
