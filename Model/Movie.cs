using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Model
{
	public class Movie
	{
		[Key, Required]
		public int Id { get; set; }
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Running Time is required"), Range(1, 600, ErrorMessage = "Running time must be between 1 minute and 600 minutes")]
		public int RunningTime { get; set; }
		[StringLength(100, ErrorMessage = "Director name can not exceed 100 characters")]
		public string Director { get; set; }
		public string Genre { get; set; }
		public string Rating { get; set; }

		public virtual List<Session> Sessions { get; set; }
	}
}
