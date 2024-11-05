using CustomClothing.Repositorio.Contract;
using CustomClothing.Repositorio;
using CustomClothing.GerenciarArquivo;
using CustomClothing.Libraries.Login;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
//Injetando os repositórios na Controller
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IPersonalizarRepositorio, PersonalizarRepositorio>();
builder.Services.AddScoped<IitemRepositorio, ItemRepositorio>();

builder.Services.AddScoped<GerenciadorArquivos>();
builder.Services.AddScoped<CustomClothing.Cookie.Cookies>();
builder.Services.AddScoped<CustomClothing.CarrinhoCompra.CookiesCarrinhoCompra>();

builder.Services.AddScoped<CustomClothing.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<LoginCliente>();

//Corrigir problema com TEMPDATA
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //Definir um tempo para duração.
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    //Mostrar para o navegador que o cookie é essencial
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider();

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
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseCookiePolicy();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
