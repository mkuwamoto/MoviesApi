using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto;
using MoviesApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
	public class ManagerController : BaseController
	{
		public ManagerController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

		[HttpGet]
		public IEnumerable<Manager> GetManagers()
		{
			return _context.Manager;
		}

		[HttpGet("{id}")]
		public IActionResult GetManagersById(int id)
		{
			Manager manager = _context.Manager.FirstOrDefault(x => x.Id == id);
			if (manager == null) return NotFound();
			GetManagerDto managerDto = _mapper.Map<GetManagerDto>(manager);
			return Ok(managerDto);
		}

		[HttpPost]
		public IActionResult CreateManager([FromBody] CreateManagerDto managerDto)
		{
			Manager manager = _mapper.Map<Manager>(managerDto);
			_context.Manager.Add(manager);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetManagersById), new { Id = manager.Id }, manager);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateManager(int id, [FromBody] UpdateManagerDto managerDto)
		{
			Manager manager = _context.Manager.FirstOrDefault(x => x.Id == id);
			if (manager == null) return NotFound();
			_mapper.Map(managerDto, manager);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
