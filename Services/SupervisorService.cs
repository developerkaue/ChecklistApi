using AutoMapper;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;
using ChecklistApi.Repository;
using System.Runtime.CompilerServices;

namespace ChecklistApi.Services
{
    public class SupervisorService :ISupervisorService
    {
        private readonly ISupervisorRepository _supervisorRepository;
        private readonly IMapper _mapper;

        public SupervisorService(ISupervisorRepository supervisorRepository, IMapper mapper)
        {
            _supervisorRepository = supervisorRepository;
            _mapper = mapper;
        }

        public async Task<SupervisorDTO> GetSupervisorById(int id)
        {
            var supervisor = await _supervisorRepository.GetSupervisorById(id);
            return _mapper.Map<SupervisorDTO>(supervisor);
        }

        public async Task<IEnumerable<SupervisorDTO>> GetAllAsync()
        {
            var supervisor = await _supervisorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupervisorDTO>>(supervisor);
        }

        public async Task AddAsync(SupervisorDTO supervisorDTO)
        {
            var supervisor = _mapper.Map<Supervisor>(supervisorDTO);
            await _supervisorRepository.AddAsync(supervisor);
        }

        public async Task UpdateAsync(SupervisorDTO supervisorDTO, int id)
        {
            var supervisor = await _supervisorRepository.GetSupervisorById(id);
            if (supervisor == null) throw new Exception("Supervisor não encontrado");
            _mapper.Map(supervisorDTO, supervisor);
            await _supervisorRepository.UpdateAsync(supervisor);
        }

        public async Task DeleteAsync(int id)
        {
            await _supervisorRepository.DeleteAsync(id);
        }

    }
}
