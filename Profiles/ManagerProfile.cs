using AutoMapper;
using MoviesApi.Data.Dto;
using MoviesApi.Model;

namespace MoviesApi.Profiles
{
	public class ManagerProfile : Profile
	{
		public ManagerProfile()
		{
			CreateMap<CreateManagerDto, Manager>();
			CreateMap<Manager, GetManagerDto>();
			CreateMap<UpdateManagerDto, Manager>();
		}
	}
}
