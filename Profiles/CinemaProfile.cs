using MovieAPI.Data.Dtos;
using AutoMapper;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
    }
}
