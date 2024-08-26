using AutoMapper;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;
using ChecklistApi.Models;

namespace ChecklistApi.Services
{
    public class ItemChecklistService : IItemChecklistService
    {
        private readonly IItemChecklistRepository _itemChecklistRepository;
        private readonly IMapper _mapper;
        public ItemChecklistService(IItemChecklistRepository itemChecklistRepository, IMapper mapper)
        {
            _itemChecklistRepository = itemChecklistRepository;
            _mapper = mapper;
        }

        public async Task<ItemChecklistDTO> GetItemChecklistById(int id)
        {
            var itemChecklist= await _itemChecklistRepository.GetItemChecklistById(id);
            return _mapper.Map<ItemChecklistDTO>(itemChecklist);
        }

        public async Task<IEnumerable<ItemChecklistDTO>> GetAllAsync()
        {
            var itemChecklist = await _itemChecklistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemChecklistDTO>>(itemChecklist);
        }

        public async Task AddAsync(ItemChecklistDTO itemChecklistDTO)
        {
            var itemChecklist = _mapper.Map<ItemChecklist>(itemChecklistDTO);
            await _itemChecklistRepository.AddAsync(itemChecklist);
        }

        public async Task UpdateAsync(ItemChecklistDTO itemChecklistDTO, int id)
        {
            var itemChecklist = await _itemChecklistRepository.GetItemChecklistById(id);
            if (itemChecklist == null) throw new Exception("Executor não encontrado");
            _mapper.Map(itemChecklistDTO, itemChecklist);
            await _itemChecklistRepository.UpdateAsync(itemChecklist);
        }

        public async Task DeleteAsync(int id)
        {
            await _itemChecklistRepository.DeleteAsync(id);
        }
    }
}
