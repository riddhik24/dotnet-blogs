using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using BlogAPI.Data;
using BlogAPI.DTOs;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorResoponseDto>> CreateAuthor(AuthorCreateDto dto)
        {
            var newAuthor = new Author{
                Name = dto.Name,
                Email = dto.Email,
            };

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            var responseData = new AuthorResoponseDto {
                Id = newAuthor.Id,
                Name=newAuthor.Name,
                Email=newAuthor.Email
            };

            return Ok(responseData);
        }
    }
}