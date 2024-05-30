using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;
using HotelBooking.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("Customer")]
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return View(customerDtos);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var customers = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDto>(customers);
            return View(customers);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return View(customerDto);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerDto customerDto)
        {
            if (id != customerDto.CustomerID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(customerDto);
                await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return View(customerDto);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Customers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
    
}
