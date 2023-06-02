using TpInvestigacion.Data.Entidades;
using TpInvestigacion.Data.Interface;
using TpInvestigacion.Data;
using TpInvestigacion.Servicio.Interface;
using TpInvestigacion.Servicio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<TpInvestigacionContext>();
builder.Services.AddSingleton<IServicio, Servicio>();
builder.Services.AddSingleton<IRepositorio, Repositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
