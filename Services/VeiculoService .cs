using AutoMapper;
using ChecklistApi.Models;
using ChecklistApi.DTO_s;
using ChecklistApi.Interfaces;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public async Task<VeiculoDTO> GetVeiculoById(int id)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        return _mapper.Map<VeiculoDTO>(veiculo);
    }

    public async Task<IEnumerable<VeiculoDTO>> GetAllVeiculos()
    {
        var veiculos = await _veiculoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
    }

    public async Task AddVeiculo(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Veiculo>(veiculoDTO);
        await _veiculoRepository.AddAsync(veiculo);
    }

    public async Task UpdateVeiculo(int id, VeiculoDTO veiculoDTO)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id);
        if (veiculo == null) throw new Exception("Veículo não encontrado");

        _mapper.Map(veiculoDTO, veiculo); // Atualiza a entidade com os valores do DTO
        await _veiculoRepository.UpdateAsync(veiculo);
    }

    public async Task DeleteVeiculo(int id)
    {
        await _veiculoRepository.DeleteAsync(id);
    }
}
