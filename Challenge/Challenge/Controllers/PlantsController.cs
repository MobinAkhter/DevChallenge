using Challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly PlantContext _context;

        public PlantsController(PlantContext context)
        {
            _context = context;
           
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlants()
        {
            return Ok(await _context.Plants.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetPlant",
                new { id = plant.Id },
                plant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPlant(int id, Plant plant)
        {
            if (id != plant.Id)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Plants.Any(p => p.Id == id))
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
        public async Task<ActionResult<Plant>> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return plant;
        }

    }
}
