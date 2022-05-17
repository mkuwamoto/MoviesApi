using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dto.Theater
{
	public class UpdateTheaterDto
	{
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
