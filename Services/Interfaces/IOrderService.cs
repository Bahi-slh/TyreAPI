using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Models.DTOs;

namespace TyreManagementAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(CreateOrderDto orderDto);
        Task UpdateOrderAsync(int id, UpdateOrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}