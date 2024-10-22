using Microsoft.EntityFrameworkCore;
using ReservacionesRESTFULL.Bussiness.Services;
using ReservacionesRESTFULL.Data.Repositories;
using ReservacionesRESTFULL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar contexto de BD (Crear el objeto en tiempo de ejecución)
builder.Services.AddDbContext<AppDBContext>(
    context =>
    {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

//Inyección de repositorios
builder.Services.AddScoped<BookRepository>();

builder.Services
    .AddScoped<IBookService, BookServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
