using ReviewGenerator.Core.Models;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review> GetReview();
        public Task Add(Review rawReview);
    }
}
