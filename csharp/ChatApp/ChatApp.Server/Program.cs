using ChatApp.Server.Contracts;
using ChatApp.Server.Models;
using Supabase;

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

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/room", async( CreateRoomsRequest request , 
    Supabase.Client client)  => {
            var room = new room
            {
                Name = request.Name,
                CreatedAt = request.CreatedAt
            };    

            var response = await client .From<room>().Insert(room);
            var newRoom = response.Models.First();
        return Results.Ok(newRoom); 

    });


app.MapGet("/room/{id}", async(long id, Supabase.Client client) => {
    
    var response = await client.From<room>().Where(n => n.Id == id).Get(); 
    var room = response.Models.FirstOrDefault();
    
    if (room  is null) {
        return Results.NotFound();
    }
    
    var roomResponse = new room {
        Id = room.Id, 
        Name = room.Name,
        CreatedAt = room.CreatedAt
    }; 

    return Results.Ok(roomResponse);    

});

app.MapDelete("/room/{id}", async(long id, Supabase.Client client) => {
    await client.From<room>().Where(n => n.Id == id).Delete();
    return Results.NoContent();    
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
