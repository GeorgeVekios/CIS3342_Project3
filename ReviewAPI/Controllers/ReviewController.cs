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
            AddReviewOp addReviewOp = new AddReviewOp();
            addReviewOp.AddReview(review);

            return CreatedAtAction(nameof(GetReviewsByUserID), new { userID = review.UserID }, review);
        }

        [HttpGet("byID/{reviewID}")]
        public IActionResult GetReviewByID(int reviewID)
        {
            Debug.WriteLine("Trying to fetch ReviewID: " + reviewID);
            GetReviewByIDOp getReviewByIDOp = new GetReviewByIDOp();
            Review review = getReviewByIDOp.GetReviewByID(reviewID);

            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPut("{reviewID}")]
        public IActionResult UpdateReview(int reviewID, [FromBody] Review review)
        {
            if (review == null || review.ReviewID != reviewID)
            {
                return BadRequest("Invalid review data or reviewID mismatch");
            }

            UpdateReviewOp updateReviewOp = new UpdateReviewOp();
            int rowsAffected = updateReviewOp.UpdateReview(review);

            if (rowsAffected <= 0)
            {
                return NotFound("Review not found or update failed");
            }
            return NoContent();
        }

        [HttpDelete("{reviewID}")]
        public IActionResult DeleteReview(int reviewID)
        {
            DeleteReviewOp deleteReviewOp = new DeleteReviewOp();
            int rowsAffected = deleteReviewOp.DeleteReview(reviewID);

            if (rowsAffected <= 0)
            {
                return NotFound("Review Not Found");
            }
            return NoContent();
        }
    }
}
