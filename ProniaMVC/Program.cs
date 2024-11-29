using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>

opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))

);
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(

    "defoult",
    "{controller=home}/{action=index}/{id?}"


    );


app.Run();
