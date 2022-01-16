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
                review.Overall = await GetReviewRating();
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

        private async Task<int> GetReviewRating()
        {
            return await Task.Run(() =>
            {
                Random rnd = new Random();
                return rnd.Next(1, 6);
            });
        }

    }
}
