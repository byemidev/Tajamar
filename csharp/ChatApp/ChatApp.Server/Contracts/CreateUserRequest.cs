using Microsoft.AspNetCore.Mvc.Routing;

namespace ChatApp.Server.Contracts
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
    }
}
