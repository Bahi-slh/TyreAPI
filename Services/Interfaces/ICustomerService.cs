using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Models.DTOs;

namespace TyreManagementAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(CreateCustomerDto customerDto);
        Task UpdateCustomerAsync(int id, UpdateCustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}