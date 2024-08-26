using ChecklistApi.DTO_s;


public interface IVeiculoService
{
    Task<VeiculoDTO> GetVeiculoById(int id);       
    Task<IEnumerable<VeiculoDTO>> GetAllVeiculos(); 
    Task AddVeiculo(VeiculoDTO veiculoDTO);       
    Task UpdateVeiculo(int id, VeiculoDTO veiculoDTO); 
    Task DeleteVeiculo(int id);                    
}
