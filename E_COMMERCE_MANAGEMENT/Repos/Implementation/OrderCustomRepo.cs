using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.DTOs;
using E_COMMERCE_MANAGEMENT.Enums;
using E_COMMERCE_MANAGEMENT.Models;
using E_COMMERCE_MANAGEMENT.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Implementation
{
    public class OrderCustomRepo : GenericRepo<Order>, IOrder
    {
        private readonly My_AppContext _context;
        public OrderCustomRepo(My_AppContext c) : base(c)
        {
            _context = c;
        }

        public async Task<ICollection<OrderDTOWithTotalRevenue>> CalculateTotalRevenue()
        {
            return await _context.Orders
                .Where(x => x.Status == StatusEnum.Completed)
                .GroupBy(x => x.Id)
                .Select(x => new OrderDTOWithTotalRevenue
                {
                    Id = x.Key,
                    TotalRevenue = x.Sum(x => x.TotalAmount)
                }).ToListAsync();
        }

        public async Task<TotalAmountDTO?> GetByIdWithItemDetails(int id)
        {
            return await _context.Orders
                .Include(x => x.OrderItems)
                .Where(x => x.Id == id)
                .Select(x => new TotalAmountDTO
                {
                    Id = x.Id,
                    Status = x.Status,
                    OrderDate = x.OrderDate,
                    TotalPrice = x.OrderItems.Sum(x => x.Quantity * x.UnitPrice)
                }).FirstOrDefaultAsync();
        }
    }
}
