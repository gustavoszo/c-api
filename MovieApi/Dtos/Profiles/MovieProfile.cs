using AutoMapper;
using MovieApi.Models;

namespace MovieApi.Dtos.Profiles
{
    public class MovieProfile : Profile
    {

        public MovieProfile() 
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Movie, ResponseMovieDto>();
        }

    }
}
