using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using TyreManagementAPI.Data;
using TyreManagementAPI.Models.DTOs;
using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Services.Interfaces;

namespace TyreManagementSystem.Services
{
    public class TyreService : ITyreService
    {
        private readonly ApplicationDbContext _context;

        public TyreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tyre>> GetAllTyresAsync()
        {
            return await _context.Tyres.ToListAsync();
        }

        public async Task<Tyre> GetTyreByIdAsync(int id)
        {
            return await _context.Tyres.FindAsync(id);
        }

        public async Task<Tyre> CreateTyreAsync(CreateTyreDto tyreDto)
        {
            var tyre = new Tyre
            {
                Brand = tyreDto.Brand,
                Model = tyreDto.Model,
                Size = tyreDto.Size,
                Price = tyreDto.Price,
                StockQuantity = tyreDto.StockQuantity
            };

            _context.Tyres.Add(tyre);
            await _context.SaveChangesAsync();
            return tyre;
        }

        public async Task UpdateTyreAsync(int id, UpdateTyreDto tyreDto)
        {
            var tyre = await _context.Tyres.FindAsync(id);
            if (tyre == null)
            {
                throw new NotFoundException("Tyre not found");
            }

            tyre.Brand = tyreDto.Brand ?? tyre.Brand;
            tyre.Model = tyreDto.Model ?? tyre.Model;
            tyre.Size = tyreDto.Size ?? tyre.Size;
            tyre.Price = tyreDto.Price ?? tyre.Price;
            tyre.StockQuantity = tyreDto.StockQuantity ?? tyre.StockQuantity;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTyreAsync(int id)
        {
            var tyre = await _context.Tyres.FindAsync(id);
            if (tyre != null)
            {
                _context.Tyres.Remove(tyre);
                await _context.SaveChangesAsync();
            }
        }
    }
}