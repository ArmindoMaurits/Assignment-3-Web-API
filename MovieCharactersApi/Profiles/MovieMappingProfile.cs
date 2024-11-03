using AutoMapper;
using MovieCharactersApi.Models.Requests;
using MovieCharactersApi.Models.Responses;

namespace MovieCharactersApi.Profiles;
public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Data.Entities.Movie, MovieResponseDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title)
            )
            .ForMember(
                dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre)
            )
            .ForMember(
                dest => dest.ReleaseYear,
                opt => opt.MapFrom(src => src.ReleaseYear)
            )
            .ForMember(
                dest => dest.Director,
                opt => opt.MapFrom(src => src.Director)
            )
            .ForMember(
                dest => dest.PictureUrl,
                opt => opt.MapFrom(src => src.PictureUrl)
            )
            .ForMember(
                dest => dest.TrailerUrl,
                opt => opt.MapFrom(src => src.TrailerUrl)
            )
            .ForMember(
                dest => dest.Characters,
                opt => opt.MapFrom(src => src.Characters)
            )
            .ForMember(
                dest => dest.FranchiseId,
                opt => opt.MapFrom(src => src.FranchiseId)
            )
            .ForMember(
                dest => dest.Franchise,
                opt => opt.MapFrom(src => src.Franchise)
            )
            .ReverseMap();

        CreateMap<MovieCreateRequestDto, Data.Entities.Movie>()
            .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title)
            )
            .ForMember(
                dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre)
            )
            .ForMember(
                dest => dest.ReleaseYear,
                opt => opt.MapFrom(src => src.ReleaseYear)
            )
            .ForMember(
                dest => dest.Director,
                opt => opt.MapFrom(src => src.Director)
            )
            .ForMember(
                dest => dest.PictureUrl,
                opt => opt.MapFrom(src => src.PictureUrl)
            )
            .ForMember(
                dest => dest.TrailerUrl,
                opt => opt.MapFrom(src => src.TrailerUrl)
            )
            .ForMember(
                dest => dest.FranchiseId,
                opt => opt.MapFrom(src => src.FranchiseId)
            );
    }
}
