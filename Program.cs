using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Services;
using DinkToPdf.Contracts;
using DinkToPdf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDeions => apiDeions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddDbContext<VoeAirLinesSenaiContext>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<ManutencaoService>();
builder.Services.AddTransient<CancelamentoService>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<VooService>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
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
