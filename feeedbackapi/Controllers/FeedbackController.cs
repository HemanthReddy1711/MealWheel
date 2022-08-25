using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using feeedbackapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace feeedbackapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
            private readonly MealWheelDBContext _context;

            public FeedbackController(MealWheelDBContext context)
            {
                _context = context;
            }

            //GET: api/Products
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
            {
                return await _context.Feedbacks.ToListAsync();
            }

            //GET: api/Products/1
            [HttpGet("{Id}")]
            public async Task<ActionResult<Feedback>> GetFeedbacks(int id)
            {
                var product = await _context.Feedbacks.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }

        //POST: api/Feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedbacks(Feedback feed)
        {
            _context.Feedbacks.Add(feed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedback", new { id = feed.Id}, feed);
        }


        //PUT: api/Products/2
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, Feedback )
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool ProductsExist(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }


    }
}
