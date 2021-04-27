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
   
    public class EmployeesController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public EmployeesController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("Check/{email}")]
        public bool Employees(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}