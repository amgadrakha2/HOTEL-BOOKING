using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;
using HotelBooking.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("HotelBranches")]
    public class HotelBranchesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelBranchesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var hotelBranches = await _unitOfWork.HotelBranches.GetAllAsync();
            var hotelBranchDtos = _mapper.Map<IEnumerable<HotelBranchDto>>(hotelBranches);
            return View(hotelBranchDtos);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var hotelBranch = await _unitOfWork.HotelBranches.GetByIdAsync(id);
            if (hotelBranch == null)
            {
                return NotFound();
            }
            var hotelBranchDto = _mapper.Map<HotelBranchDto>(hotelBranch);
            return View(hotelBranchDto);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(HotelBranchDto hotelBranchDto)
        {
            if (ModelState.IsValid)
            {
                var hotelBranch = _mapper.Map<HotelBranch>(hotelBranchDto);
                await _unitOfWork.HotelBranches.AddAsync(hotelBranch);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelBranchDto);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var hotelBranch = await _unitOfWork.HotelBranches.GetByIdAsync(id);
            if (hotelBranch == null)
            {
                return NotFound();
            }
            var hotelBranchDto = _mapper.Map<HotelBranchDto>(hotelBranch);
            return View(hotelBranchDto);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, HotelBranchDto hotelBranchDto)
        {
            if (id != hotelBranchDto.BranchID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var hotelBranch = _mapper.Map<HotelBranch>(hotelBranchDto);
                await _unitOfWork.HotelBranches.UpdateAsync(hotelBranch);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelBranchDto);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hotelBranch = await _unitOfWork.HotelBranches.GetByIdAsync(id);
            if (hotelBranch == null)
            {
                return NotFound();
            }
            var hotelBranchDto = _mapper.Map<HotelBranchDto>(hotelBranch);
            return View(hotelBranchDto);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.HotelBranches.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

    }
    
}
