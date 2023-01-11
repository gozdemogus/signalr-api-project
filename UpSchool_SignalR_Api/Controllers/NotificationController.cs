using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UpSchool_SignalR_Api.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSchool_SignalR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;

        public NotificationController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("{roomCount}")]
        public async Task<IActionResult> SetRoomCount(int roomCount)
        {
            //MyHub icerisindeki roomCount değiskeni artık apiden gelen değiskeni alacak
            MyHub.roomCount = roomCount;
            await _hubContext.Clients.All.SendAsync("Notify", $"Bu oda en fazla {roomCount} kişi olabilir");
            return Ok();
        }
    }
}

