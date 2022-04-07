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
    public class ElevatorController : ControllerBase
    {
        private readonly weverMysqlContext _context;

        public ElevatorController(weverMysqlContext context)
        {
            _context = context;
        }

        // GET: api/Elevator
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Elevator>>> GetElevators()
        // {
        //     return await _context.Elevators.ToListAsync();
        // }

        // // GET: api/Elevator/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Elevator>> GetElevator(long id)
        // {
        //     var elevator = await _context.Elevators.FindAsync(id);

        //     if (elevator == null)
        //     {
        //         return NotFound();
        //     }

        //     return elevator;
        // }

        // GET: api/Elevator/5/Status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetElevatorStatus(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.Status;
        }

        // GET: api/Elevator/Broken
        // Returns list of elevators with status not equal to "Running"
        [HttpGet("Broken")]
        public async Task<ActionResult<IEnumerable<Elevator>>> Getbrokenelevators()
        {
            var elevators = await _context.Elevators.Where(e => e.Status != "Running").ToListAsync();

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

        // PUT: api/Elevator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        // {
        //     if (id != elevator.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(elevator).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!ElevatorExists(id))
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

        // PUT: api/Elevator/5/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevatorStatus(long id, [FromBody] Elevator elevatorUpdate)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            elevator.Status = elevatorUpdate.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
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

        // POST: api/Elevator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        // {
        //     _context.Elevators.Add(elevator);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetElevator", new { id = elevator.Id }, elevator);
        // }

        // // DELETE: api/Elevator/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteElevator(long id)
        // {
        //     var elevator = await _context.Elevators.FindAsync(id);
        //     if (elevator == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Elevators.Remove(elevator);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool ElevatorExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
