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
    public class BatteryController : ControllerBase
    {
        private readonly weverMysqlContext _context;

        public BatteryController(weverMysqlContext context)
        {
            _context = context;
        }

        // // GET: api/Battery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // // GET: api/Battery/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Battery>> GetBattery(long id)
        // {
        //     var battery = await _context.Batteries.FindAsync(id);

        //     if (battery == null)
        //     {
        //         return NotFound();
        //     }

        //     return battery;
        // }

        // GET: api/Battery/5/Status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetColumnStatus(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }

        // PUT: api/Battery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBattery(long id, Battery battery)
        // {
        //     if (id != battery.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(battery).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BatteryExists(id))
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
        
        // PUT: api/Battery/5/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryStatus(long id, [FromBody] Battery batteryUpdate)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            battery.Status = batteryUpdate.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
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

        // POST: api/Battery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Battery>> PostBattery(Battery battery)
        // {
        //     _context.Batteries.Add(battery);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        // }

        // // DELETE: api/Battery/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteBattery(long id)
        // {
        //     var battery = await _context.Batteries.FindAsync(id);
        //     if (battery == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Batteries.Remove(battery);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool BatteryExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}
