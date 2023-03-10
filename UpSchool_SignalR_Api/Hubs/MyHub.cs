using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_SignalR_Api.Models;

namespace UpSchool_SignalR_Api.Hubs
{
    public class MyHub : Hub
    {
        private readonly Context _context;

        public MyHub(Context context)
        {
           _context = context;
        }

        public static List<string> Names { get; set; } = new List<string>();

        public static int ClientCount { get; set; } = 0;

        public static int roomCount { get; set; } = 7;

        //public async Task SendName(string name)
        //{
        //    Names.Add(name);
        //    await Clients.All.SendAsync("ReceiveName", name);
        //}

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }

        //baglanınca 1 artar
        public async override Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
        }

        public async Task SendName(string name)
        {
            if (Names.Count >= roomCount)
            {
                await Clients.Caller.SendAsync("Error", $"Bu oda en fazla {roomCount} kişi kadar üye alabilir");
            }
            else
            {
                Names.Add(name);
                await Clients.All.SendAsync("ReceiveName", name);
            }
        }

        public async Task SendNameByGroup(string name, string roomName)
        {
            var room = _context.Rooms.Where(x => x.RoomName == roomName).FirstOrDefault();
            if (room != null)
            {
                room.Users.Add(new User
                {
                    Name = name
                });
            }
            else
            {
                var newRoom = new Room
                {
                    RoomName = roomName
                };
                newRoom.Users.Add(new User { Name = name });
                _context.Rooms.Add(new Room());
            }
            await _context.SaveChangesAsync();
            await Clients.Group(roomName).SendAsync("ReceiveMessageByGroup", name, room.RoomID);
        }

        public async Task GetNamesByGroup()
        {
            var rooms = _context.Rooms.Include(x => x.Users).Select(y => new
            {
                roomId = y.RoomID,
                Users = y.Users.ToList()
            });

            await Clients.All.SendAsync("ReceiveNamesByGroup", rooms);
        }

        public async Task AddToGroup(string roomName)
        {
            //groups default geliyor
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task RemoveToGroup(string roomName)
        {
            //groups default geliyor
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
