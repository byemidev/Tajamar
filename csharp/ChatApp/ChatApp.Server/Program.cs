using ChatApp.Server.Contracts;
using ChatApp.Server.Models;
using Microsoft.IdentityModel.Tokens;
using Supabase;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



var supaUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");

var supaKey = Environment.GetEnvironmentVariable("SUPABASE_ACCESS_TOKEN");
//Supabase client as a service
builder.Services.AddScoped<Supabase.Client>( _ => new Supabase.Client(
        supaUrl,
        supaKey, 
        new SupabaseOptions { 
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        }
    ));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

//securing jwt secret for expose in API  
var bytes = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JwtSecret"]!);

builder.Services.AddAuthentication().AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey (bytes),
        ValidAudience = builder.Configuration["Authentication:validAudience"],
        ValidIssuer = builder.Configuration["Authentication:ValidIssuer"]
    };
});

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Exposing endpoints 

//POST /room
app.MapPost("/room", async( CreateRoomRequest request , 
    Supabase.Client client)  => {
            var room = new room
            {
                Name = request.Name,
                Description = request.Description
            };    

            var response = await client.From<room>().Insert(room);
            var newRoom = response.Models.First();
        
        return Results.Ok(newRoom.Id); 

    }).RequireAuthorization();

//GET /room/{id}
app.MapGet("/room/{id}", async(long id, Supabase.Client client) => {
    
    var response = await client.From<room>().Where(n => n.Id == id).Get(); 
    var room = response.Models.FirstOrDefault();
    
    if (room  is null) {
        return Results.NotFound();
    }
    
    var roomResponse = new RoomsResponse
    {
        Id = room.Id, 
        Name = room.Name,
        Description = room.Description,
        CreatedAt = room.CreatedAt 
    }; 

    return Results.Ok(roomResponse);    

});


//DELETE /room/{id}
app.MapDelete("/room/{id}", async (long id, Supabase.Client client) => {
    await client.From<room>().Where(n => n.Id == id).Delete();
    return Results.NoContent();    
});


//POST /user
app.MapPost("/user", async( CreateUserRequest request, Supabase.Client client) => {
    var user = new user { 
        Name = request.Name,
        AvatarUrl = request.AvatarUrl, 
    };

    var response = await client.From<user>().Insert(user);
    var newUser = response.Models.First();

    return Results.Ok(newUser.Id);    

});

//GET /user/{id}
app.MapGet("/user/{id}", async (long id, Supabase.Client client ) => {
    var response = await client.From<user>().Where(n => n.Id == id).Get();
    
    var user = response.Models.FirstOrDefault();

    if (user is null) { 
        return Results.NotFound();
    }

    var userResponse = new UsersResponse
    {
        Id = user.Id,
        Name = user.Name,
        AvatarUrl = user.AvatarUrl,
        CreatedAt = user.CreatedAt
    };

    return Results.Ok(userResponse);    
});

//DELETE  /user/{id}
app.MapDelete("/user/{id}", async(long id, Supabase.Client client) => {
    
    await client.From<user>().Where(n => n.Id == id).Delete();
    
    return Results.NoContent();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
