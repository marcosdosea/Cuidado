using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Service;

namespace CuidadoWeb
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			var connectionString = builder.Configuration.GetConnectionString("CuidadoDatabase") ?? throw new InvalidOperationException(); ;
			builder.Services.AddDbContext<CuidadoContext>(options =>
			{
				options.UseMySQL(connectionString);
			});

			builder.Services.AddTransient<IProdutoService, ProdutoService>();
			builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
            builder.Services.AddTransient<IVisitanteService, VisitanteService>();

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
