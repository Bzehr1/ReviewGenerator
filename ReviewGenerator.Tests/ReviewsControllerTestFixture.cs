using Microsoft.Extensions.Logging;
using Moq;
using ReviewGenerator.Controllers;
using ReviewGenerator.Core.Interfaces;
using Xunit;

namespace ReviewGenerator.Tests
{
    public class ReviewsControllerTestFixture
    {
        private ReviewsController reviewsController;
        private Mock<ILogger<ReviewsController>> loggerMock;
        private Mock<IReviewService> reviewServiceMock;
        public ReviewsControllerTestFixture()
        {
            loggerMock = new Mock<ILogger<ReviewsController>>();
            reviewServiceMock = new Mock<IReviewService>();
            reviewsController = new ReviewsController(loggerMock.Object, reviewServiceMock.Object);
        }

        [Fact]
        public void GetReview_Returns_NotNullReview()
        {
            Assert.NotNull(reviewsController.GenerateReview());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(1000)]
        public void GetReviews_Returns_NotNullReviewList(int numberOfReviews)
        {
            Assert.NotNull(reviewsController.GenerateReviews(numberOfReviews));
        }

    }
}
