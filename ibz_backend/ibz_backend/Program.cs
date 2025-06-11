using ibz_backend.Data;// agregar esto porque truena
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<miembroData>();// agregar esto porque truena
builder.Services.AddSingleton<variosData>();// agregar esto porque truena

builder.Services.AddCors(options =>//AGREGANDO CORS
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");// agregar para el CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
