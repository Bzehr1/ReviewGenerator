using Markov;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Models;
using ReviewGenerator_Core;
using System;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private MarkovChain<string> _chain = new MarkovChain<string>(1);

        public async Task<Review> GetReview()
        {
            return await Task.Run(() =>
            {
                Review review = new Review();
                review.ReviewText = GetReviewText();
                review.Overall = GetReviewRating(review.ReviewText);
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

        private string GetReviewText()
        {
            return string.Join(" ", _chain.Chain(new Random()));
        }

        private int GetReviewRating(string reviewText)
        {

            var reviewData = new SentimentModel.ModelInput()
            {
                Col0 = reviewText
            };

            var result = SentimentModel.Predict(reviewData);

            Random rnd = new Random();

            return result.Prediction == 1 ? rnd.Next(3, 6) : rnd.Next(1, 3);
        }

    }
}
