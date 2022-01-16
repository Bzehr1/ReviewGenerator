using NUnit.Framework;
using Moq;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Services;
using System;
using System.Threading.Tasks;
using System.IO;

namespace ReviewGenerator.Test
{
    public class ReviewServiceTestFixture
    {
        private ReviewService reviewService;
        private Mock<IReviewRepository> reviewRepositoryMock;

        [SetUp]
        public void Setup()
        {
            reviewRepositoryMock = new Mock<IReviewRepository>();
            reviewService = new ReviewService(reviewRepositoryMock.Object);
        }

        [Test]
        public void GetReview_Returns_NotNullReview()
        {
            Assert.IsNotNull(reviewService.GetReview());
        }

    }
}