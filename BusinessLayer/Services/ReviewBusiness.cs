using BusinessLayer.Interfaces;
using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ReviewBusiness : IReviewBusinesscs
    {
        private readonly IReviewRepo reviewRepo;

        public ReviewBusiness(IReviewRepo reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }

        public AddReview AddReviews(long userId, AddReview reviews)
        {
            return reviewRepo.AddReviews(userId, reviews);
        }
        public IEnumerable<ReviewResponse> GetAllReviews(int bookId)
        {
            return reviewRepo.GetAllReviews(bookId);
        }
    }
}
