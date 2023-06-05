using Control_Inventario.Models;
using Control_Inventario.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<Context>("Data Source=CPTI225\\SQLEXPRESS;Initial Catalog=PedidosDb;Integrated Security=True;Encrypt=False");
builder.Services.AddScoped<IPedido_ProveedorService,Pedido_ProveedorService>();

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
