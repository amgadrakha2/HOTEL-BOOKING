using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;
using HotelBooking.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{

    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            var paymentDtos = _mapper.Map<IEnumerable<PaymentDto>>(payments);
            return View(paymentDtos);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var payments = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDto>(payments);
            return View(paymentDto);

        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentDto paymentDto)
        {

            if (ModelState.IsValid)
            {
                var payment = _mapper.Map<Payment>(paymentDto);
                await _unitOfWork.Payments.AddAsync(payment);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return View(paymentDto);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.PaymentID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var payment = _mapper.Map<Payment>(paymentDto);
                await _unitOfWork.Payments.UpdateAsync(payment);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return View(paymentDto);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Payments.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
