using WebApplication1.UISample.Services;

namespace WebApplication1.UISample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //interface ile injektion yapacaðýmýz için belirtmeliyiz.
        builder.Services.AddScoped<IApiService, ApiService>();
        builder.Services.AddScoped<IArtistUIService, ArtistUIService>();
        builder.Services.AddScoped<IUserUIService, UserUIService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

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
           //pattern: "{controller=Auth}/{action=Login}/{id?}");

        app.Run();
    }
}