using ChatApp.Server.Models;

namespace ChatApp.Server.Contracts
{
        public class RoomsResponse
        {
            //done
            public long Id { get; set; }
            public string Name{ get; set; }
            public string Description{ get; set; }
            public DateTime CreatedAt { get; set; }
    }
}
