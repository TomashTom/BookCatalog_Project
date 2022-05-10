using BookCatalog_Project.Repository;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBook, InMemoryBookRepository>();
builder.Services.AddControllers();
builder.Services.AddRouting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(
        nameof: "api",
        pattern: "{controller=books}/{id?}");
    endpoints.MapControllers();
});*/
app.MapControllers();
    

    
//app.MapControllers();
app.UseRouting();

app.Run();
