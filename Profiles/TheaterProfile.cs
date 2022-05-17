using AutoMapper;
using MoviesApi.Data.Dto.Theater;
using MoviesApi.Model;

namespace MoviesApi.Profiles
{
	public class TheaterProfile: Profile
	{
		public TheaterProfile()
		{
			CreateMap<CreateTheaterDto, Theater>();
			CreateMap<Theater, GetTheaterDto>();
			CreateMap<UpdateTheaterDto, Theater>();
		}
	}
}
