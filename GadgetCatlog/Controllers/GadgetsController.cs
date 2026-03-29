using Microsoft.AspNetCore.Mvc;
using GadgetCatlog.Data;
using GadgetCatlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GadgetCatlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GadgetsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGadgetById(int id)
        {
            var gadget = await _context.Catlog.FindAsync(id);

            if(gadget == null) return NotFound(new {message = $"Gadget with ID {id} was not found"});

            return Ok(gadget);
        }


        [HttpGet]
        public async Task<IActionResult> GetGadgets(
            [FromQuery] string? category,
            [FromQuery] int page=1,
            [FromQuery] int pageSize = 10
        )
        {
            if(page ==0 || pageSize<=0) return BadRequest("Invalid Page or PageSize");  

            IQueryable<Catlog> query = _context.Catlog;

            if(!string.IsNullOrWhiteSpace(category)){ query = query.Where(g=>g.Category.ToLower() == category.ToLower());}

            var pagedGadgets = await query.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

            return Ok(new
            {
                CurrentPage = page,
                ItemsReturned = pagedGadgets.Count,
                Data = pagedGadgets
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateGadget([FromBody] Catlog catlog)
        {
            _context.Catlog.Add(catlog);
            await _context.SaveChangesAsync();
            return Ok(catlog);
        }
    }
}