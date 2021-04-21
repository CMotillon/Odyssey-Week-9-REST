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
    [Route("api/Buildings")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BuildingsController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public BuildingsController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("Quotes")]
        public async Task<ActionResult<IEnumerable<Quotes>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        [HttpGet("Leads")]
        public async Task<ActionResult<IEnumerable<Leads>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/buildings
        // Retrieving a list of Buildings requiring intervention 
        [HttpGet("Intervention")]
        public ActionResult<List<Buildings>> GetToFixBuildings()
        {
            IQueryable<Buildings> ToFixBuildingsList = from bat in _context.Buildings
            join Batteries in _context.Batteries on bat.Id equals Batteries.BuildingId 
            join Columns in _context.Columns on Batteries.Id equals Columns.BatteryId
            join Elevators in _context.Elevators on Columns.Id equals Elevators.ColumnId
            where (Batteries.Status == "Intervention") || (Columns.Status == "Intervention") || (Elevators.Status == "Intervention")
            select bat;
            return ToFixBuildingsList.Distinct().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Buildings>> Getbuildings(long id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }
    }
}