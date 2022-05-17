using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Context;

namespace MoviesApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseController : ControllerBase
	{
		protected AppDbContext _context;
		protected IMapper _mapper;

		public BaseController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
