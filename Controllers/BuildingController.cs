#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly weverMysqlContext _context;

        public BuildingController(weverMysqlContext context)
        {
            _context = context;
        }

        // GET: api/Building
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        // {
        //     return await _context.Buildings.ToListAsync();
        // }

        // // GET: api/Building/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Building>> GetBuilding(long id)
        // {
        //     var building = await _context.Buildings.FindAsync(id);

        //     if (building == null)
        //     {
        //         return NotFound();
        //     }

        //     return building;
        // }

        // GET: api/Building/interventions
        // Returns list of leads with status not equal to "Running"
        [HttpGet("interventions")]
        public async Task<ActionResult<IEnumerable<Building>>> GetInterventions()
        {
            var innerJoinQuery =
                from building in _context.Buildings
                from battery in building.Batteries
                from column in battery.Columns
                from elevator in column.Elevators
                where battery.Status.Equals("Intervention") || column.Status.Equals("Intervention") || elevator.Status.Equals("Intervention")
                select building;

            var distinctBuildings = (
                from building in innerJoinQuery
                select building).Distinct();
            
            return await distinctBuildings.ToListAsync();
        }

        // PUT: api/Building/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBuilding(long id, Building building)
        // {
        //     if (id != building.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(building).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BuildingExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Building
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Building>> PostBuilding(Building building)
        // {
        //     _context.Buildings.Add(building);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        // }

        // // DELETE: api/Building/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBuilding(long id)
        // {
        //     var building = await _context.Buildings.FindAsync(id);
        //     if (building == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Buildings.Remove(building);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool BuildingExists(long id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
