using Microsoft.EntityFrameworkCore;
using ReservacionesRESTFULL.Bussiness.Services;
using ReservacionesRESTFULL.Data;
using ReservacionesRESTFULL.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar contexto de BD (Crear el objeto en tiempo de ejecuci�n)
builder.Services.AddDbContext<AppDBContext>(
    context =>
    {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

//Inyecci�n de repositorios
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<ReservationRepository>();

builder.Services
    .AddScoped<IReservationService, ReservationServiceImpl>();   

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
