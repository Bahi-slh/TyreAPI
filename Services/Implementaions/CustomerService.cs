using Microsoft.EntityFrameworkCore;
using TyreManagementAPI.Data;
using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Models.DTOs;
using TyreManagementAPI.Services.Interfaces;
using OpenQA.Selenium;

namespace TyreManagementAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(CreateCustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found");
            }

            customer.Name = customerDto.Name ?? customer.Name;
            customer.Email = customerDto.Email ?? customer.Email;
            customer.PhoneNumber = customerDto.PhoneNumber ?? customer.PhoneNumber;
            customer.Address = customerDto.Address ?? customer.Address;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}