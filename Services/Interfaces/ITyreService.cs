using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Models.DTOs;

namespace TyreManagementAPI.Services.Interfaces
{
    public interface ITyreService
    {
        Task<IEnumerable<Tyre>> GetAllTyresAsync();
        Task<Tyre> GetTyreByIdAsync(int id);
        Task<Tyre> CreateTyreAsync(CreateTyreDto tyreDto);
        Task UpdateTyreAsync(int id, UpdateTyreDto tyreDto);
        Task DeleteTyreAsync(int id);
    }
}