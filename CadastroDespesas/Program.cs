using CadastroDespesas.Infra.Database;
using CadastroDespesas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DespesasControlContext>();

builder.Services.AddScoped<IDespesasService, DespesasService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Despesas}/{action=Index}/{id?}");

app.Run();
