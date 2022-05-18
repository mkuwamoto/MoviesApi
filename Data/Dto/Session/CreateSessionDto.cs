using System;

namespace MoviesApi.Data.Dto
{
	public class CreateSessionDto
	{
		public int TheaterId { get; set; }
		public int MovieId { get; set; }
		public DateTime EndingTime { get; set; }
	}
}
