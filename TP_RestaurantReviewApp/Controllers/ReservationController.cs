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
                viewModel.Reservation = new Reservation(); //resetting form
                return View(new Reservation()); //resetting controls
            }
            catch (Exception ex)
            {
                viewModel.Message = $"Error submitting reservation: {ex.Message}";
                return View(viewModel);
            }
        }

        [HttpGet("Reservation/ManageReservationPage")]
        public IActionResult ManageReservationPage(int reservationId)
        {

            GetReservationByReservationIDOp getResByID = new GetReservationByReservationIDOp();
            var reservation = new Reservation();

            reservation = getResByID.GetReservationByReservationID(reservationId);

            var viewModel = new ManageReservationPageViewModel
            {
                RestaurantID = reservation.RestId,
                Reservation = reservation
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateReservation(ManageReservationPageViewModel viewModel)
        {
            UpdateReservationOp updateReservationOp = new UpdateReservationOp();
            if (ModelState.IsValid)
            {
                //updating reservation in db
                updateReservationOp.UpdateReservation(viewModel.Reservation);
                viewModel.Message = "Reservation Updated Successfully";
            }
            return View(viewModel);
        }
    }
}
