using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dto.Theater
{
	public class GetTheaterDto
	{
        [Key, Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
