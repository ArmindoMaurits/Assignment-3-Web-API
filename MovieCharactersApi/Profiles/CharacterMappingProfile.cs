using AutoMapper;
using MovieCharactersApi.Models.Requests;
using MovieCharactersApi.Models.Responses;

namespace MovieCharactersApi.Profiles
{
    public class CharacterMappingProfile : Profile
    {
        public CharacterMappingProfile()
        {
            CreateMap<Data.Entities.Character, CharacterResponseDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Alias,
                    opt => opt.MapFrom(src => src.Alias)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                )
                .ForMember(
                    dest => dest.PictureUrl,
                    opt => opt.MapFrom(src => src.PictureUrl)
                );

            CreateMap<CharacterCreateRequestDto, Data.Entities.Character>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Alias,
                    opt => opt.MapFrom(src => src.Alias)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                )
                .ForMember(
                    dest => dest.PictureUrl,
                    opt => opt.MapFrom(src => src.PictureUrl)
                );

            CreateMap<CharacterUpdateRequestDto, Data.Entities.Character>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Alias,
                    opt => opt.MapFrom(src => src.Alias)
                )
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.Gender)
                )
                .ForMember(
                    dest => dest.PictureUrl,
                    opt => opt.MapFrom(src => src.PictureUrl)
                );
        }
    }
}
