using E_COMMERCE_MANAGEMENT.DTOs;
using E_COMMERCE_MANAGEMENT.Models;

namespace E_COMMERCE_MANAGEMENT.Repos.Interfaces
{
    public interface IOrder : IGenericRepo<Order>
    {
        Task<TotalAmountDTO?> GetByIdWithItemDetails(int id);
        Task<ICollection<OrderDTOWithTotalRevenue>> CalculateTotalRevenue();
    }
}
