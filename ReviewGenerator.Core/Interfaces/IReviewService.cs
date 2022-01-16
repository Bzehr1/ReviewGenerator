using ReviewGenerator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Interfaces
{
    public interface IReviewService
    {
        Task<Review> GetReview();
        Task<List<Review>> GetReviews(int numberOfReviews);
    }
}
