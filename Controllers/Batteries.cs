using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;
using Microsoft.AspNetCore.Cors;

using Pomelo.EntityFrameworkCore.MySql;



namespace Rocket_Elevators_Rest_API.Models.Controllers
{   [ApiController]
    [Route("api/[controller]")]
   
    public class BatteriesController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public BatteriesController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Batteries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBattery(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }
        
        [HttpGet("status/{id}")]
        public async Task<ActionResult<String>> GetElevatorStatus(long id)
        {
            //Get the elevator having specified id 
            var elevator = await _context.Batteries.FindAsync(id);
            //check if no elevetor is returned 
            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.Status.ToString();
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmodifyBatterisStatus(long id, [FromBody] Batteries body)
        {



            if (body.Status == null)
                return BadRequest();

            var battery = await _context.Batteries.FindAsync(id);
            battery.Status = body.Status;          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteriesExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }


        // GET: api/Batteries/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetBatteryStatus( long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }

       // POST: api/Batteries/{id}/status
       [HttpPost]
        public async Task<ActionResult<Batteries>> PostBattery(Batteries battery)
        {
            _context.Batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.Id }, battery);
        }

     
      // DELETE: Batteries
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batteries>> DeleteBattery(int id)
        {
            var battery = await _context.Batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return battery;
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> columnEdit(long id, [FromBody] Batteries body)
        {
            var bat = await _context.Batteries.FindAsync(id);
            bat.Information = body.Information;
            bat.Notes = body.Notes;          
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!BatteriesExists(id))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }

        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    } 
}