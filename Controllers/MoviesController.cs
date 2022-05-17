using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto;
using MoviesApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
	public class MoviesController : BaseController
	{
		public MoviesController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

		[HttpGet]
		public IEnumerable<Movie> GetMovies()
		{
			return _context.Movies;
		}

		[HttpPost]
		public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
		{
			try
			{
				Movie movie = _mapper.Map<Movie>(movieDto);
				_context.Movies.Add(movie);
				_context.SaveChanges();
				return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
			}
			catch
			{
				return StatusCode(500);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetMovieById(int id)
		{

			Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie == null) return NotFound();
			var movieDto = _mapper.Map<GetMovieDto>(movie);
			return Ok(movieDto);
		}

		[HttpPut("{id}")]
		public IActionResult EditMovie(int id, [FromBody] UpdateMovieDto movieDto)
		{
			Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie == null) return NotFound();
			_mapper.Map(movieDto, movie);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id)
		{
			Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie == null) return NotFound();
			_context.Remove(movie);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
