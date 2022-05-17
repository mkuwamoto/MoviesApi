﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Model
{
	public class Manager
	{
		[Key, Required]
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Theater> Theaters { get; set; }
	}
}
