using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto.Theater;
using MoviesApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
	public class TheatersController : BaseController
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public TheatersController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<Theater> GetTheaters()
		{
			return _context.Theaters;
		}

		[HttpGet("{id}")]
		public IActionResult GetTheaterById(int id)
		{
			Theater theater = _context.Theaters.FirstOrDefault(x => x.Id == id);
			return Ok(theater);
		}

		[HttpPost]
		public IActionResult CreateTheater([FromBody] CreateTheaterDto theaterDto)
		{
			Theater theater = _mapper.Map<Theater>(theaterDto);
			_context.Theaters.Add(theater);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetTheaterById), new { Id = theater.Id }, theater);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateTheater(int id, [FromBody] UpdateTheaterDto theaterDto)
		{
			Theater theater = _context.Theaters.FirstOrDefault(x => x.Id == id);
			if (theater == null) return NotFound();
			_mapper.Map(theaterDto, theater);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTheater(int id)
		{
			Theater theater = _context.Theaters.FirstOrDefault(x => x.Id == id);
			if (theater == null) return NotFound();
			_context.Remove(theater);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
