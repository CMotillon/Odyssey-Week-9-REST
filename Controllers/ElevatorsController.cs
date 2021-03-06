using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Rocket_Elevators_Rest_API.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class ElevatorsController : ControllerBase
    {
        //Declare context attribute
        private readonly rocketelevators_developmentContext _context;

        //Constructor
        public ElevatorsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevators>>> Getelevators()
        {
            return await _context.Elevators.ToListAsync();
        }

        [HttpGet("statuscheck")]
        public IEnumerable<Elevators> GetBadStatus()
        {
            IQueryable<Elevators> elevators = from l in _context.Elevators
            where l.Status == "Stopped"
            select l;
            return elevators.ToList();
        }


        // GET api/elevators
        [HttpGet("status/{status}")]
        // User is free to check different status : in our case just make intervention 
        public IEnumerable<Elevators> GetIntervention(string status)
        {
            //Prepare the request 
            IQueryable<Elevators> elevators = from l in _context.Elevators
            //define condition status should be equal to given values 
            where l.Status == status
            select l;
            //show results 
            return elevators.ToList();

        }

        // GET api/elevators/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> Getelevators(long id)
        {
            //Get the elevator having specified id 
            var elevator = await _context.Elevators.FindAsync(id);
            //check if no elevetor is returned 
            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }
        
        [HttpGet("status/{id}")]
        public async Task<ActionResult<String>> GetElevatorStatus(long id)
        {
            //Get the elevator having specified id 
            var elevator = await _context.Elevators.FindAsync(id);
            //check if no elevetor is returned 
            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.Status.ToString();
        }

        [HttpPut("changeStatus/{id}")]
        public async Task<IActionResult> PutmodifyElevatorsStatus(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            elevator.Status = "Moving";          
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!elevatorExists(id))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }
        
        // PUT api/elevators/id
        // Request to change elevator status 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmodifyElevatorsStatus(long id, [FromBody] Elevators body)
        {
            //check body 
            if (body.Status == null)
                return BadRequest();
            //find corresponding elevator 
            var elevator = await _context.Elevators.FindAsync(id);
            //change status 
            elevator.Status = body.Status;          
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!elevatorExists(id))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> elevatorEdit(long id, [FromBody] Elevators body)
        {
            var elevator = await _context.Elevators.FindAsync(id);
            elevator.Information = body.Information;
            elevator.Notes = body.Notes;          
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!elevatorExists(id))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }

        [HttpPost("Contract/{address}")]
        public async Task<ActionResult<Contract>> PostContract(string address)
        {
            Contract contract = new Contract();
            contract.Address = address;

            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostContract", new { address = contract.Address }, contract);
        }
        [HttpPut("Contractedit/{address}")]
        public async Task<IActionResult> elevatorEdit(string address, [FromBody] Contract body)
        {
            var contract = await _context.Contract.FindAsync(address);
            
           
            contract.Batteries = body.Batteries;
            contract.Columns = body.Columns;
            contract.Elevators = body.Elevators;
            contract.Doors = body.Doors;
            contract.Buttons = body.Buttons;
            contract.Displays = body.Displays;        
            try
            {
                //save change 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //catch error - elevetor doesn't exist 
                if (!contractExists(address))
                    return NotFound();
                else
                    throw;
            }
            //return succeed message 
            return new OkObjectResult("success");
        }

        [HttpGet("GetContracts")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContract()
        {
            return await _context.Contract.ToListAsync();
        }

        private bool elevatorExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }

        private bool contractExists(string address){
            return _context.Contract.Any(e => e.Address == address);
        }
    }
}