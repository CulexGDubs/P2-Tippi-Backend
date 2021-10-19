using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using TrippiBL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User newUser)
        {
            User addedUser = await _bl.AddUserAsync(newUser);
            return Created("api/[controller]", addedUser);
        }

        
    }
}
