using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data.Context;
using MoviesApi.Data.Dto;
using MoviesApi.Model;

namespace MoviesApi.Controllers
{
	public class AddressesController : BaseController
	{

		public AddressesController(AppDbContext context, IMapper mapper) : base(context, mapper) { }

		[HttpGet]
		public IEnumerable<Address> GetAddresses()
		{
			return _context.Address;
		}

		[HttpPost]
		public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
		{
			try
			{
				Address address = _mapper.Map<Address>(addressDto);
				_context.Address.Add(address);
				_context.SaveChanges();
				return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
			}
			catch
			{
				return StatusCode(500);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetAddressById(int id)
		{

			Address address = _context.Address.FirstOrDefault(x => x.Id == id);
			if (address == null) return NotFound();
			var addressDto = _mapper.Map<GetAddressDto>(address);
			return Ok(addressDto);
		}

		[HttpPut("{id}")]
		public IActionResult EditAddress(int id, [FromBody] UpdateAddressDto addressDto)
		{
			Address address = _context.Address.FirstOrDefault(x => x.Id == id);
			if (address == null) return NotFound();
			_mapper.Map(addressDto, address);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAddress(int id)
		{
			Address address = _context.Address.FirstOrDefault(x => x.Id == id);
			if (address == null) return NotFound();
			_context.Remove(address);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
