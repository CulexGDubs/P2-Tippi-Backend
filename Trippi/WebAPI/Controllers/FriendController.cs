using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrippiBL;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private IBL _bl;
        public FriendController(IBL bl)
        {
            _bl = bl; 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Friends newFriend)
        {
            Friends addedFriend = await _bl.AddFriendAsync(newFriend);
            return Created("api/[controller]", addedFriend);
        }
    }
}
