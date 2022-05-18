using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dto
{
	public class CreateTheaterDto
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		public int AddressId { get; set; }
		public int ManagerId { get; set; }
	}
}
