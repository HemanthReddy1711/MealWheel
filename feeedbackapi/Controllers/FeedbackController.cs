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

        }
    }
