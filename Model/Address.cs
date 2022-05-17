using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Model
{
	public class Address
	{
		[Required, Key]
		public int Id { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public int Number { get; set; }
	}
}
