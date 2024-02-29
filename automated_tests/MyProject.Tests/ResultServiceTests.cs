using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MyProject.Service;
using Xunit;

namespace MyProject.Tests
{
    public class ResultServiceTests
    {
        [Fact]
        public void SetRecentOverweightResult_ForOverweightResult_UpdatesProperty()
        {
            var result = new BmiResult { BmiClassification = BmiClassification.Overweight };
            var resultService = new ResultService(new ResultRepository());

            resultService.SetRecentOverweightResult(result);

            resultService.RecentOverweightResult.Should().Be(result);
        }

        [Fact]
        public void SetRecentOverweightResult_ForOverweightResult_DoesntUpdateProperty()
        {
            var result = new BmiResult { BmiClassification = BmiClassification.Obesity };
            var resultService = new ResultService(new ResultRepository());

            resultService.SetRecentOverweightResult(result);

            resultService.RecentOverweightResult.Should().BeNull();
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
        {
            var result = new BmiResult { BmiClassification = BmiClassification.Underweight };
            var repoMock = new Mock<IResultRepository>();

            var resultService = new ResultService(repoMock.Object);

            await resultService.SaveUnderweightResultAsync(result);

            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
        }

        public async Task SaveUnderweightResultAsync_ForUnderweightResult_DoesntInvokeSaveResultAsync()
        {
            var result = new BmiResult { BmiClassification = BmiClassification.Normal };
            var repoMock = new Mock<IResultRepository>();

            var resultService = new ResultService(repoMock.Object);

            await resultService.SaveUnderweightResultAsync(result);

            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
        }
    }
}
