using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto;
using MoviesApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
	public class TheatersController : BaseController
	{
		public TheatersController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

		[HttpGet]
		public IEnumerable<Theater> GetTheaters()
		{
			return _context.Theaters;
		}

		[HttpGet("{id}")]
		public IActionResult GetTheaterById(int id)
		{
			Theater theater = _context.Theaters.FirstOrDefault(x => x.Id == id);
			if (theater == null) return NotFound();
			GetTheaterDto theaterDto = _mapper.Map<GetTheaterDto>(theater);
			return Ok(theaterDto);
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
