using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ViccController : Controller
    {
        private readonly ViccDbContext _context;

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

        public async Task<ActionResult<Vicc>> GetVicc(int id) 
        {
            var vicc = _context.Viccek.Find(id);
            if (vicc == null) {return NotFound();}
            return vicc; 
        }

        //feltoltes

        [HttpPost]
        public async Task<ActionResult> PostVicc(Vicc feltoltottVicc) 
        {
            _context.Viccek.Add(feltoltottVicc);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //modositas

        [HttpPut("{id}")]


        public async Task<ActionResult> PutVicc(int id, Vicc modositottVicc)
        {
            //var vicc = _context.Viccek.Find(id);
            if (id != modositottVicc.Id) { return BadRequest(); }
            _context.Entry(modositottVicc).State = EntityState.Modified;
             await _context.SaveChangesAsync();

            return NoContent(); 
        }


    }   
}
