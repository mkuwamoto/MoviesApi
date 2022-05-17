using MoviesApi.Model;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dto
{
	public class GetTheaterDto
	{
        [Key, Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
