using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> GetReview()
        {
            return await Task.Run(async() =>
            {
                return await _reviewRepository.GetReview();
            });
        }

        public async Task<List<Review>> GetReviews(int numberOfReviews)
        {
            return await Task.Run(async () =>
            {
                List<Review> reviewList = new List<Review>();
                while(numberOfReviews > 0)
                {
                    reviewList.Add(await _reviewRepository.GetReview());
                    numberOfReviews--;
                }
                return reviewList;
            });
        }
    }
}
