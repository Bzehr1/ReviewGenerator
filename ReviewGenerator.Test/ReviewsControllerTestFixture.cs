using NUnit.Framework;
using Moq;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Services;
using System;
using System.Threading.Tasks;
using System.IO;
using ReviewGenerator.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReviewGenerator.Test
{
    public class ReviewsControllerTestFixture
    {
        private ReviewsController reviewsController;
        private Mock<ILogger<ReviewsController>> loggerMock;
        private Mock<IReviewService> reviewServiceMock;

        [SetUp]
        public void Setup()
        {
            loggerMock = new Mock<ILogger<ReviewsController>>();
            reviewServiceMock = new Mock<IReviewService>();
            reviewsController = new ReviewsController(loggerMock.Object, reviewServiceMock.Object);
        }

        [Test]
        public void GetReview_Returns_NotNullReview()
        {
            Assert.IsNotNull(reviewsController.GenerateReview());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000)]
        public void GetReviews_Returns_NotNullReviewList(int numberOfReviews)
        {
            Assert.IsNotNull(reviewsController.GenerateReviews(numberOfReviews));
        }

    }
}