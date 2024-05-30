using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;
using HotelBooking.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("Rooms")]
    public class RoomsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var rooms = await _unitOfWork.Rooms.GetAllAsync();
            var roomDtos = _mapper.Map<IEnumerable<RoomDto>>(rooms);
            return View(roomDtos);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomDto roomDto)
        {
            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomDto);
                await _unitOfWork.Rooms.AddAsync(room);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomDto);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var roomDto = _mapper.Map<RoomDto>(room);
            return View(roomDto);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomDto roomDto)
        {
            if (id != roomDto.RoomID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomDto);
                await _unitOfWork.Rooms.UpdateAsync(room);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomDto);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            var roomDto = _mapper.Map<RoomDto>(room);
            return View(roomDto);
        }
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Rooms.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var rooms = await _unitOfWork.Rooms.GetByIdAsync(id);
            if ( rooms== null)
            {
                return NotFound();
            }
            var roomsDto = _mapper.Map<RoomDto>(rooms);
            return View(roomsDto);
        }
    }
}
