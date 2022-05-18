﻿using MoviesApi.Model;
using System;

namespace MoviesApi.Data.Dto
{
	public class GetSessionDto
	{
		public int Id { get; set; }
		public int TheaterId { get; set; }
		public int MovieId { get; set; }
		public DateTime EndingTime { get; set; }

		public virtual Theater Theater { get; set; }
		public virtual Movie Movie { get; set; }
	}
}
