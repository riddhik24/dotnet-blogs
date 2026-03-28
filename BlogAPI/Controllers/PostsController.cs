using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Data;
using BlogAPI.Models;
using BlogAPI.DTOs;
namespace BlogAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResponseDto>>> GetPosts()
        {

            var posts = await  _context.Posts.Include(p=>p.Author).ToListAsync();
            var responseDtos = posts.Select(post=> new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorName = post.Author.Name,
            }).ToList();

            return Ok(responseDtos);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(PostCreateDto dto)
        {
            var authorExists = await _context.Authors.AnyAsync(a => a.Id == dto.AuthorId);
            if(!authorExists) return BadRequest("Author not found");

            var newPost = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                AuthorId = dto.AuthorId
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return Ok("Posts created successfully.");
        }
    }
}