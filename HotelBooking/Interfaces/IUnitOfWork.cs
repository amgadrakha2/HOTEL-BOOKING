namespace HotelBooking.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IHotelBranchRepository HotelBranches { get; }
        IRoomRepository Rooms { get; }
        IBookingRepository Bookings { get; }
        IPaymentRepository Payments {  get; }
        Task<int> CompleteAsync();
    }
}
