using AutoMapper;
using MoviesApi.Data.Dto;
using MoviesApi.Model;

namespace MoviesApi.Profiles
{
	public class SessionProfile : Profile
	{
		public SessionProfile()
		{
			CreateMap<CreateSessionDto, Session>();
			CreateMap<Session, GetSessionDto>()
				.ForMember(dto => dto.StartTime, opts => opts
				.MapFrom(dto => dto.EndingTime.AddMinutes(dto.Movie.RunningTime * (-1)))
				);
			CreateMap<UpdateSessionDto, Session>();
		}
	}
}
