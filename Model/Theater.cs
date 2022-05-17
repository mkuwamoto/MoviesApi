using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Model
{
	public class Theater
	{
		[Key]
		[Required]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		public int AddressId { get; set; }
		public int ManagerId { get; set; }
		public virtual Address Address { get; set; }
		public virtual Manager Manager { get; set; }

	}
}
