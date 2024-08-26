﻿using ChecklistApi.Models;

namespace ChecklistApi.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetByIdAsync(int id);
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task AddAsync(Veiculo veiculo);
        Task UpdateAsync(Veiculo veiculo);
        Task DeleteAsync(int id);
    }
}
