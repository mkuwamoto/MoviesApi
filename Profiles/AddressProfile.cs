using AutoMapper;
using MoviesApi.Data.Dto;
using MoviesApi.Model;

namespace MoviesApi.Profiles
{
	public class AddressProfile : Profile
	{
		public AddressProfile()
		{
			CreateMap<CreateAddressDto, Address>();
			CreateMap<Address, GetAddressDto>();
			CreateMap<UpdateAddressDto, Address>();
		}
	}
}