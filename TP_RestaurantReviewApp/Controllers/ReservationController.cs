using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using ObjectClassLibrary;
using System.Diagnostics;
using DBOperationsClassLibrary;
using TP_RestaurantReviewApp.Models;
using ReservationDBOperations;


namespace TP_RestaurantReviewApp.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet("Reservation/CreateReservationPage")]
        public IActionResult CreateReservationPage(int restaurantId)
        {
            var viewModel = new CreateReservationPageViewModel
            {
                Reservation = new Reservation(),
                RestaurantID = restaurantId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateReservationPage(CreateReservationPageViewModel viewModel)
        {
            var reservation = viewModel.Reservation;
            AddReservationOp addReservationOp = new AddReservationOp();
            try
            {
                addReservationOp.AddReservation(reservation);
                viewModel.Message = "Reservation submitted successfully!";
                viewModel.Reservation = new Reservation(); // Reset form
                return View(new Reservation()); //reset controls
            }
            catch (Exception ex)
            {
                viewModel.Message = $"Error submitting reservation: {ex.Message}";
                return View(viewModel);
            }
        }
    }
}
