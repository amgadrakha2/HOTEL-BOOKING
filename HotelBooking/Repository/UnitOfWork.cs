using BookingHotel.Data;
using HotelBooking.Interfaces;

namespace HotelBooking.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            HotelBranches = new HotelBranchRepository(_context);
            Rooms= new RoomRepository(_context);
            Bookings= new BookingRepository(_context);
            Payments= new PaymentRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IHotelBranchRepository HotelBranches { get; private set; }
        public IRoomRepository Rooms { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IPaymentRepository Payments { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
