using System.Text.Json;
using PracticaNetCore.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var url = "https://rickandmortyapi.com/documentation/#rest";
JsonSerializerOptions options = new JsonSerializerOptions(){
    PropertyNameCaseInsensitive = true
};
using (var httpClient = new HttpClient()){
    var response = await httpClient.GetAsync(url);
    if(response.IsSuccessStatusCode){
        var content = await response.Content.ReadAsStringAsync();
        var api = JsonSerializer.Deserialize<List<Result>>(content, options);
        foreach (var item in api)
        {
            Console.WriteLine($"{item.id} {item.name}");
            
        }
    }
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
