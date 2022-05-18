using MoviesApi.Model;
using System.Collections.Generic;

namespace MoviesApi.Data.Dto
{
	public class GetManagerDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public object Theaters { get; set; }
	}
}
