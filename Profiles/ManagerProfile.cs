using AutoMapper;
using MoviesApi.Data.Dto;
using MoviesApi.Model;
using System.Linq;

namespace MoviesApi.Profiles
{
	public class ManagerProfile : Profile
	{
		public ManagerProfile()
		{
			CreateMap<CreateManagerDto, Manager>();
			CreateMap<UpdateManagerDto, Manager>();
			CreateMap<Manager, GetManagerDto>()
				.ForMember(manager => manager.Theaters, opts => opts
				.MapFrom(manager => manager.Theaters.Select(
					t => new { t.Id, t.Name, t.Address, t.AddressId }
					)));
		}
	}
}
