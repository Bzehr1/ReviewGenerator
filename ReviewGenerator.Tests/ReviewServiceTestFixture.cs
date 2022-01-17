using Moq;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Services;
using Xunit;

namespace ReviewGenerator.Tests
{
    public class ReviewServiceTestFixture
    {
        private ReviewService reviewService;
        private Mock<IReviewRepository> reviewRepositoryMock;

        public ReviewServiceTestFixture()
        {
            reviewRepositoryMock = new Mock<IReviewRepository>();
            reviewService = new ReviewService(reviewRepositoryMock.Object);
        }

        [Fact]
        public void GetReview_Returns_NotNullReview()
        {
            Assert.NotNull(reviewService.GetReview());
        }

    }
}
