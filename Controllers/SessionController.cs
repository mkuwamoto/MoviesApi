using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto;
using MoviesApi.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MoviesApi.Controllers
{
	public class SessionController : BaseController
	{
		public SessionController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

		[HttpGet]
		public IEnumerable<Session> GetSessions()
		{
			return _context.Sessions;
		}

		[HttpGet("{id}")]
		public IActionResult GetSessionsById(int id)
		{
			Session session = _context.Sessions.FirstOrDefault(x => x.Id == id);
			if (session == null) return NotFound();
			GetSessionDto sessionDto = _mapper.Map<GetSessionDto>(session);
			return Ok(sessionDto);
		}

		[HttpPost]
		public IActionResult CreateSession([FromBody] CreateSessionDto sessionDto)
		{
			try
			{
				Session session = _mapper.Map<Session>(sessionDto);
				_context.Sessions.Add(session);
				_context.SaveChanges();
				return CreatedAtAction(nameof(GetSessionsById), new { Id = session.Id }, session);
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateSession(int id, [FromBody] UpdateSessionDto sessionDto)
		{
			Session session = _context.Sessions.FirstOrDefault(x => x.Id == id);
			if (session == null) return NotFound();
			_mapper.Map(sessionDto, session);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSession(int id)
		{
			Session session = _context.Sessions.FirstOrDefault(x => x.Id == id);
			if (session == null) return NotFound();
			_context.Remove(session);
			_context.SaveChanges();
			return NoContent();
		}

	}
}
