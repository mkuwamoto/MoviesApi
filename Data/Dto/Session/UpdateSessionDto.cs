namespace MoviesApi.Data.Dto
{
	public class UpdateSessionDto
	{
		public int TheaterId { get; set; }
		public int MovieId { get; set; }
		public DateTime EndingTime { get; set; }
	}
}
