using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private TicketSystemnewContext context;
        public CategoryController(TicketSystemnewContext DbContext) {

            context = DbContext;
        
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Category> res=context.Categories.ToList();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
               
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           Category? res= await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
