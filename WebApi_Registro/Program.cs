using Microsoft.EntityFrameworkCore;
using WebApi_Registro.DataContext;
using WebApi_Registro.Service.CargoService;
using WebApi_Registro.Service.DepartamentoService;
using WebApi_Registro.Service.FuncionarioService;
using WebApi_Registro.Service.ProjetoService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
builder.Services.AddScoped<IDepartamentoInterface, DepartamentoService>();
builder.Services.AddScoped<ICargoInterface, CargoService>();
builder.Services.AddScoped<IProjetoInterface, ProjetoService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
