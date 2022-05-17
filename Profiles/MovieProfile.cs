using AutoMapper;
using MoviesApi.Data.Dto;
using MoviesApi.Model;

namespace MoviesApi.Profiles
{
	public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			CreateMap<CreateMovieDto, Movie>();
			CreateMap<Movie, GetMovieDto>();
			CreateMap<UpdateMovieDto, Movie>();
		}
	}
}
