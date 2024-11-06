using AutoMapper;
using MovieCharactersApi.Models.Responses;

namespace MovieCharactersApi.Profiles;

public class FranchiseMappingProfile : Profile
{
    public FranchiseMappingProfile()
    {
        CreateMap<Data.Entities.Franchise, FranchiseResponseDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ReverseMap();

        CreateMap<Models.Requests.FranchiseCreateRequestDto, Data.Entities.Franchise>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            );

        CreateMap<Models.Requests.FranchiseUpdateRequest, Data.Entities.Franchise>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            );
    }
}
