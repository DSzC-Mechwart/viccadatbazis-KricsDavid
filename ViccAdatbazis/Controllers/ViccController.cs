using Microsoft.AspNetCore.Mvc;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ViccController : Controller
    {

        //vicc listazas
        [HttpGet]
        public async Task<ActionResult<List<Vicc>>> GetViccek() { 
            return await _context.Viccek.Where(x => x.Aktiv).ToListAsync();
        }
        public ViccController(ViccDbContext context) 
        { 
            _context = context;
        }

        //list

        [HttpGet]

        


        //lekeres
        [HttpGet("{id}")]

    }   
}
