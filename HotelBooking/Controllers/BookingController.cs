using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;
using HotelBooking.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("Bookings")]
    public class BookingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            var bookingDtos = _mapper.Map<IEnumerable<BookingDto>>(bookings);
            return View(bookingDtos);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDto = _mapper.Map<BookingDto>(booking);
            return View(bookingDto);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDto bookingDto)
        {
            if (ModelState.IsValid)
            {
                var countNumOfNights= await _unitOfWork.Bookings.CountNumberOfNights(bookingDto.CheckInDate, bookingDto.CheckOutDate, bookingDto.RoomID,bookingDto.NumberOfRooms);
                var booking = _mapper.Map<Booking>(bookingDto);

                // Check if the customer has previous bookings
                var customer = await _unitOfWork.Customers.GetByIdAsync(booking.CustomerID);
                if (customer != null && await _unitOfWork.Bookings.HasPreviousBookingsAsync(customer.NationalID))
                {

                    booking.TotalCost =countNumOfNights;
                }

                await _unitOfWork.Bookings.AddAsync(booking);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingDto);
        }
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDto = _mapper.Map<BookingDto>(booking);
            return View(bookingDto);
        }
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingDto bookingDto)
        {
            if (id != bookingDto.BookingID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Booking>(bookingDto);

                // Check if the customer has previous bookings
                var countNumOfNights = await _unitOfWork.Bookings.CountNumberOfNights(bookingDto.CheckInDate, bookingDto.CheckOutDate, bookingDto.RoomID, bookingDto.NumberOfRooms);
                var customer = await _unitOfWork.Customers.GetByIdAsync(booking.CustomerID);
                if (customer != null && await _unitOfWork.Bookings.HasPreviousBookingsAsync(customer.NationalID))
                {
                    booking.TotalCost = countNumOfNights;
                }

                await _unitOfWork.Bookings.UpdateAsync(booking);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingDto);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDto = _mapper.Map<BookingDto>(booking);
            return View(bookingDto);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Bookings.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
