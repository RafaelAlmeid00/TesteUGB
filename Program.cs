using Microsoft.EntityFrameworkCore;
using UGB.Data;
using UGB.Interface;
using UGB.Factory;
using UGB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UGBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=localhost;Database=UGB;Trusted_Connection=True;TrustServerCertificate=true;")));

builder.Services.AddSession(options =>
    {
        options.Cookie.Name = "MySessionCookie";
        options.IdleTimeout = TimeSpan.FromMinutes(120); // Ajuste conforme necessário
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Services.AddScoped<IFactory<IAuth>, AuthFactory>();
builder.Services.AddScoped<IUsuario, Usuario>();
builder.Services.AddScoped<IAuth, Auth>();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
