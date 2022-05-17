using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dto.Address
{
	public class GetAddressDto
	{
		[Required, Key]
		public int Id { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public int Number { get; set; }
		public DateTime GetTime { get => DateTime.Now; }
	}
}
