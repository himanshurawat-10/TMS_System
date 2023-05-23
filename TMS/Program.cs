using Microsoft.EntityFrameworkCore;
using TMS.Context;
using TMS.Interface;
using TMS.Repository;

namespace TMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyDBContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection"));
            });

            builder.Services.AddTransient<IUser, UserRepository>();
            builder.Services.AddTransient<IBatch, BatchRepository>();
            builder.Services.AddTransient<ICourse, CourseRepository>();
            builder.Services.AddTransient<IRequest, RequestRepository>();


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
        }
    }
}