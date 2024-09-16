namespace ChatApp.Server.Contracts
{
    public class CreateRoomsRequest
    {
            //todo 
            public string Name { get; set; }    
            public DateTime CreatedAt { get; set; }
        

        public class RoomsResponse
        {
            //todo
            public long Id { get; set; }
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; }

        }
    }
}
