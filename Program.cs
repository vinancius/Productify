using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//// Habilitar CORS
var s = builder.Services;
s.AddCors(c =>
   c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Productify.Context.ModelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
