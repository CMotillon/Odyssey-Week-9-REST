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
    [Route("api/Chatbot")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ChatbotController : ControllerBase
    {
        private readonly rocketelevators_developmentContext _context;

        public ChatbotController(rocketelevators_developmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<String>> Chatbot()
        {
            int nb_elevators = await _context.Elevators.ToList().Count();
            int nb_buildings = await _context.Buildings.ToList().Count();
            int nb_customers = await _context.Customers.ToList().Count();

            string answer = "There are currently" + nb_elevators + "elevators deployed in the" + nb_buildings + "buildings of your" + nb_customers + "customers.";
            return answer;
        }
    }
}