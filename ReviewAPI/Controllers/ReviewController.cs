using Microsoft.AspNetCore.Mvc;
using ObjectClassLibrary;
using ReviewDBOperations;
using System.Diagnostics;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet("{userID}")]
        public IActionResult GetReviewsByUserID(int userID)
        {
            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
            List<Review> reviewList = getReviewsByUserIDOp.GetReviewsByUserID(userID);

            return Ok(reviewList);
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Review is null");
            }

            review.UserID = 1;
            review.CreatedAt = DateTime.Now;
            Debug.WriteLine("Received: " + "ReviewID: " + review.ReviewID + " UserID: " + review.UserID + "  RestaurantID:" + review.RestaurantID + "  Title:" + review.ReviewTitle + "  Body: " + review.ReviewBody + "Ratings: " + review.AtmosphereRating + review.FoodRating + review.ServiceRating + review.PriceRating + "   VisitDate: " + review.VisitDate + "  CreatedAt: " + review.CreatedAt);
            AddReviewOp addReviewOp = new AddReviewOp();
            addReviewOp.AddReview(review);

            return CreatedAtAction(nameof(GetReviewsByUserID), new { userID = review.UserID }, review);
        }

        [HttpPut]
        public IActionResult UpdateReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Review is null");
            }

            UpdateReviewOp updateReviewOp = new UpdateReviewOp();
            updateReviewOp.UpdateReview(review);

            return NoContent();
        }

        [HttpDelete("{reviewID}")]
        public IActionResult DeleteReview(int reviewID)
        {
            DeleteReviewOp deleteReviewOp = new DeleteReviewOp();
            deleteReviewOp.DeleteReview(reviewID);

            return NoContent();
        }
    }
}
