using AutoMapper;
using ChecklistApi.Models;
using ChecklistApi.DTO_s;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeamento dos DTO`s
        CreateMap<Veiculo, VeiculoDTO>().ReverseMap();

        CreateMap<Executor, ExecutorDTO>().ReverseMap();
        CreateMap<Supervisor, SupervisorDTO>().ReverseMap();

        CreateMap<Checklist, ChecklistDTO>()
        .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));

        CreateMap<ItemChecklist, ItemChecklistDTO>();
        CreateMap<ItemChecklistDTO, ItemChecklist>();
        CreateMap<ChecklistDTO, Checklist>();

    }
}
