using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>

opt.UseSqlServer("server=DESKTOP-K0V71HO\\TEW_SQLEXPRESS;database=ProniaDb;trusted_connection=true;integrated security=true;TrustServerCertificate=true;")

);
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(

    "defoult",
    "{controller=home}/{action=index}/{id?}"


    );


app.Run();
