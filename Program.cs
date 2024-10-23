using CustomClothing.Repositorio.Contract;
using CustomClothing.Repositorio;
using CustomClothing.GerenciarArquivo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
//Injetando os reposit�rios na Controller
builder.Services.AddScoped<IPersonalizarRepositorio, PersonalizarRepositorio>();
builder.Services.AddScoped<IitemRepositorio, ItemRepositorio>();

builder.Services.AddScoped<GerenciadorArquivos>();
builder.Services.AddScoped<CustomClothing.Cookie.Cookies>();
builder.Services.AddScoped<CustomClothing.CarrinhoCompra.CookiesCarrinhoCompra>();

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
