using Microsoft.AspNetCore.Mvc;
using ObjectClassLibrary;
using RestaurantDBOperations;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RestaurantApiController : Controller
    {
        private static List<Restaurant> restaurants = new List<Restaurant>();
        private static int _nextId = 1;

        // GET: api/restaurant
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
        {
            return Ok(restaurants);
        }

        // GET: api/restaurant/{id}
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetRestaurantByUserID(int userID)
        {

            var restaurant = restaurants.FirstOrDefault(r => r.RestaurantID == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
    }
}
