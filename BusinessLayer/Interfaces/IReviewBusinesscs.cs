using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IReviewBusinesscs
    {
        public AddReview AddReviews(long userId, AddReview reviews);
        public IEnumerable<ReviewResponse> GetAllReviews(int bookId);
    }
}
