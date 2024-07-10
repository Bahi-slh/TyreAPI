using Microsoft.EntityFrameworkCore;
using TyreManagementAPI.Data;
using TyreManagementAPI.Models.DTOs;
using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Services.Interfaces;
using OpenQA.Selenium;

namespace TyreManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Tyre)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Tyre)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                {
                    TyreId = item.TyreId,
                    Quantity = item.Quantity,
                    UnitPrice = _context.Tyres.Find(item.TyreId).Price
                }).ToList()
            };

            order.TotalAmount = order.OrderItems.Sum(item => item.Quantity * item.UnitPrice);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderAsync(int id, UpdateOrderDto orderDto)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            order.CustomerId = orderDto.CustomerId;
            order.Status = orderDto.Status;

            foreach (var itemDto in orderDto.OrderItems)
            {
                var existingItem = order.OrderItems.FirstOrDefault(oi => oi.Id == itemDto.Id);
                if (existingItem != null)
                {
                    existingItem.TyreId = itemDto.TyreId;
                    existingItem.Quantity = itemDto.Quantity;
                    existingItem.UnitPrice = _context.Tyres.Find(itemDto.TyreId).Price;
                }
                else
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        TyreId = itemDto.TyreId,
                        Quantity = itemDto.Quantity,
                        UnitPrice = _context.Tyres.Find(itemDto.TyreId).Price
                    });
                }
            }

            // Remove items not in the update DTO
            order.OrderItems.RemoveAll(oi => !orderDto.OrderItems.Any(dto => dto.Id == oi.Id));

            // Recalculate total amount
            order.TotalAmount = order.OrderItems.Sum(item => item.Quantity * item.UnitPrice);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}