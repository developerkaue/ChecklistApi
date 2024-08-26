using AutoMapper;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;

namespace ChecklistApi.Services
{
    public class ExecutorService : IExecutorService
    {
        private readonly IExecutorRepository _executorRepository;
        private readonly IMapper _mapper;
        public ExecutorService(IExecutorRepository executorRepository, IMapper mapper)
        {
            _executorRepository = executorRepository;
            _mapper = mapper;
        }

        public async Task<ExecutorDTO> GetExecutorById(int id)
        {
            var executor = await _executorRepository.GetExecutorById(id);
            return _mapper.Map<ExecutorDTO>(executor);
        }

        public async Task<IEnumerable<ExecutorDTO>> GetAllAsync()
        {
            var executor = await _executorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExecutorDTO>>(executor);
        }

        public async Task AddAsync(ExecutorDTO executorDTO)
        {
            var executor = _mapper.Map<Executor>(executorDTO);
            await _executorRepository.AddAsync(executor);
        }

        public async Task UpdateAsync(ExecutorDTO executorDTO, int id)
        {
            var executor = await _executorRepository.GetExecutorById(id);
            if (executor == null) throw new Exception("Executor não encontrado");
            _mapper.Map(executorDTO, executor);
            await _executorRepository.UpdateAsync(executor);
        }

        public async Task DeleteAsync(int id)
        {
            await _executorRepository.DeleteAsync(id);
        }
    }
}
