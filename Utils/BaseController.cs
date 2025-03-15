using ecommerce_biu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T>(AppDbContext context) : ControllerBase where T : class
    {        
     
        private readonly AppDbContext _context = context;

        private readonly DbSet<T> _dbSet = context.Set<T>();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _dbSet.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.GetType().GetProperty("Id")?.GetValue(entity) }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] T entity)
        {
            var entityId = entity.GetType().GetProperty("Id")?.GetValue(entity);
            if (entityId == null || (long)entityId != id) return BadRequest();

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id < 1) return BadRequest();

            var item = await _dbSet.FindAsync(id);
            if (item == null) return NotFound();
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }

}
