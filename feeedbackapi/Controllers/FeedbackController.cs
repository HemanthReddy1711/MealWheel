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

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddProduct(Feedback product)
        {
            _context.Feedbacks.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Feedback product)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteProduct(int id)
        {
            var product = await _context.Feedbacks.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }


        private bool ProductsExist(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }



    }
}
