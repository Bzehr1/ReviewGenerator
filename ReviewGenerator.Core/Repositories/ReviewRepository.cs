using Markov;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Models;
using System;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private MarkovChain<string> _chain = new MarkovChain<string>(1);

        public async Task<Review> GetReview()
        {
            return await Task.Run(async () =>
            {
                Review review = new Review();
                review.ReviewText = await GetReviewText();
                return review;
            });
        }

        public async Task Add(Review rawReview)
        {
            if (rawReview == null || rawReview.ReviewText == null)
                throw new ArgumentNullException();

            await Task.Run(() =>
            {
                _chain.Add(rawReview.ReviewText.Split(' '));
            });
        }

        private async Task<string> GetReviewText()
        {
            return await Task.Run(() =>
            {
                return string.Join(" ", _chain.Chain(new Random()));
            });
        }

    }
}
