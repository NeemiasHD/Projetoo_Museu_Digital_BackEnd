using API_Museu_da_computacao.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/*Liberando A api pra ser acessada por qualquer lugar*/
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});


builder.Services.AddDbContext<Contexto>(options => options.UseMySql("Server=localhost;Port=3306;Database=museudacomputacao;Uid=root;Pwd=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


/*Liberando A api pra ser acessada por qualquer lugar*/
app.UseCors();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ItemAcervo}/{action=BuscarTodos}");

app.Run();
