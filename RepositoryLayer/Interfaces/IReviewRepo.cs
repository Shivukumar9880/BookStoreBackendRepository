using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IReviewRepo
    {
        public AddReview AddReviews(long userId, AddReview reviews);
        public IEnumerable<ReviewResponse> GetAllReviews(int bookId);
    }
}
