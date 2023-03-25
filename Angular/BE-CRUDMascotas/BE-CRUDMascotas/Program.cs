using BE_CRUDMascotas.AccesoDatos.ConexionBd;
using BE_CRUDMascotas.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region

builder.Services.AddSingleton<ConexioBd>();

#endregion

#region
builder.Services.AddScoped<IServicioMascota, ImplementacionMascota>();
#endregion

#region habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Habilitar CORS", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region usar CORS (ANTES DE AUTHORIZATION)
app.UseCors("Habilitar CORS");
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
