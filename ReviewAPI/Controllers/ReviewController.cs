using Microsoft.AspNetCore.Mvc;
using ObjectClassLibrary;
using ReviewAPI.Models;
using ReviewDBOperations;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        [HttpGet("{userID}")]
        public IActionResult GetReviewsByUserID(int userID)
        {
            GetReviewsByUserIDOp getReviewsByUserIDOp = new GetReviewsByUserIDOp();
            List<Review> reviewList = new List<Review>();

            return Ok(reviewList);
        }

        [HttpPost]
        public IActionResult AddReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Review is null");
            }

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
