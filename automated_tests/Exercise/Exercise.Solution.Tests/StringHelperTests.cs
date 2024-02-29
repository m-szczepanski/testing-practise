using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Exercise.Solution.Tests
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("ala ma kota", "kota ma ala")]
        [InlineData("to jest test", "test jest to")]
        [InlineData("This test checks reversing words", "words reversing checks test This")]
        public void ReverseWords_ForGivenSentence_ReturnsReversedSentence(string sentence, string expectedResult)
        {
            string result = StringHelper.ReverseWords(sentence);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("kajak", true)]
        [InlineData("niania", false)]
        public void IsPalindrome_ForGivenSentence_ReturnsBoolValue(string sentence, bool expectedResult)
        {
            bool result = StringHelper.IsPalindrome(sentence);

            result.Should().Be(expectedResult);
        }
    }
}
