using Fashion_Flex.IRepositories.Repository;
using Fashion_Flex.Models;
using Fashion_Flex.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Flex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FFContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=.;Initial Catalog=FashionFlex_DB;Integrated Security=True;TrustServerCertificate=True;")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register Repositories
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();


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
        }
    }
}
