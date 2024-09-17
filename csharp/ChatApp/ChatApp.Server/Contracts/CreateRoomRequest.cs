using ChatApp.Server.Models;
using System.Globalization;

namespace ChatApp.Server.Contracts
{
    public partial class CreateRoomRequest
    {
            //todo 
            public string Name { get; set; }
            public string Description { get; set; } 
    }
}
