using AutoMapper;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;

namespace ChecklistApi.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IMapper _mapper;

        public ChecklistService(IChecklistRepository checklistRepository, IMapper mapper)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
        }

        public async Task<ChecklistDTO> GetChecklistById (int id)
        {
            var checklist = await _checklistRepository.GetByIdAsync (id);
            return _mapper.Map<ChecklistDTO>(checklist);
        }

        public async Task<IEnumerable<ChecklistDTO>> GetAllChecklist()
        {
            var checklist = await _checklistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ChecklistDTO>>(checklist);
        }

        public async Task AddChecklist(Checklist checklist)
        {
            var checklistExistente = await _checklistRepository.GetAllLamb(c => c.VeiculoId == checklist.VeiculoId && !c.Aprovado.HasValue);
            if (checklistExistente.Any())
            {
                throw new Exception("Já existe um checklist em andamento para este veículo.");
            }

            if(checklist.Itens != null)
            {
                foreach (var item in checklist.Itens)
                {
                    item.ChecklistId = checklist.Id;
                }
            }

            await _checklistRepository.AddAsync(checklist);
        }

        public async Task UpdateChecklist(ChecklistDTO checklistDTO, int id)
        {
            var checklist = await _checklistRepository.GetByIdAsync(id);
            if (checklist == null) throw new Exception("Checklist nao encontrado");
            if (checklist.Aprovado.HasValue)
            {
                throw new Exception("Este checklist já foi finalizado e não pode ser editado.");
            }
            if (checklist.ExecutorId != checklistDTO.ExecutorId) {
                throw new Exception("Apenas o executor que iniciou o checklist pode atualizá-lo.");
            }
            _mapper.Map(checklistDTO, checklist);
            await _checklistRepository.UpdateAsync(checklist);
        }

        public async Task ApproveOrRejectChecklist(int checklistId, bool aprovado, int supervisorId)
        {
            var checklist = await _checklistRepository.GetByIdAsync(checklistId);
            if (checklist == null) throw new Exception("Checklist não encontrado");

            if (checklist.Aprovado.HasValue)
            {
                throw new Exception("Este checklist já foi finalizado e não pode ser alterado.");
            }

            checklist.SupervisorId = supervisorId;
            checklist.Aprovado = aprovado;

            await _checklistRepository.UpdateAsync(checklist);
        }

        public async Task DeleteChecklist (int id)
        {
            await _checklistRepository.DeleteAsync(id);
        }
    }
}
