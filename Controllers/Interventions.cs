using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_Rest_API.Models;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Data;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Cors;

namespace Rocket_Elevators_Rest_API.Models.Controllers
{
    [Route("api/Interventions")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class InterventionsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public InterventionsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Interventions>> PendingInterventionsList()
        {
            IQueryable<Interventions> PendingInterventionsList = from intervention in _context.Interventions
            where (intervention.Status == "Pending") && (intervention.InterventionStart == null)
            select intervention;
            return PendingInterventionsList.Distinct().ToList();
        }

        [HttpPut("InProgress/{id}")]
        public async Task<IActionResult> InterventionsInProgress(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            intervention.Status = "InProgress";
            intervention.InterventionStart = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionsExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }

        [HttpPut("Completed/{id}")]
        public async Task<IActionResult> InterventionsCompleted(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            intervention.Status = "Completed";
            intervention.InterventionEnd = DateTime.Now;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionsExists(id))
                    return NotFound();
                else
                    throw;
            }

            return new OkObjectResult("success");
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}