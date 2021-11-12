using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using LasmartTest.Shared;

namespace LasmartTest.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("LasmartTestAppDB"));

			services.AddControllersWithViews();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});

			var scope = app.ApplicationServices.CreateScope();
			var context = scope.ServiceProvider.GetService<ApiContext>();

			SeedTestData(context);
		}

		private void SeedTestData(ApiContext context)
		{
			var testDot = new Dot
			{
				PositionX = 30,
				PositionY = 30,
				Radius = 25,
				Color = "yellow"
			};
			var testDot2 = new Dot
			{
				PositionX = 200,
				PositionY = 30,
				Radius = 10,
				Color = "red"
			};
			var testDot3 = new Dot
			{
				PositionX = 500,
				PositionY = 150,
				Radius = 65,
				Color = "green"
			};

			var testComment = new Comment
			{
				BackgroundColor = "lightgrey",
				Text = "Comment 1",
				DotId = 1
			};
			var testComment2 = new Comment
			{
				BackgroundColor = "white",
				Text = "Comment 2",
				DotId = 1
			};

			var testComment3 = new Comment
			{
				BackgroundColor = "lightgrey",
				Text = "Comment 3",
				DotId = 2
			};
			var testComment4 = new Comment
			{
				BackgroundColor = "lightgrey",
				Text = "loooooooooong comment",
				DotId = 2
			};
			var testComment5 = new Comment
			{
				BackgroundColor = "white",
				Text = "Comment 5",
				DotId = 2
			};


			var testComment6 = new Comment
			{
				BackgroundColor = "lightgrey",
				Text = "Comment 6",
				DotId = 3
			};
			var testComment7 = new Comment
			{
				BackgroundColor = "yellow",
				Text = "Loooooooooong Comment 7",
				DotId = 3
			};
			var testComment8 = new Comment
			{
				BackgroundColor = "white",
				Text = "Comment 8",
				DotId = 3
			};


			context.Comments.Add(testComment);
			context.Comments.Add(testComment2);
			context.Comments.Add(testComment3);
			context.Comments.Add(testComment4);
			context.Comments.Add(testComment5);
			context.Comments.Add(testComment6);
			context.Comments.Add(testComment7);
			context.Comments.Add(testComment8);

			context.Dots.Add(testDot);
			context.Dots.Add(testDot2);
			context.Dots.Add(testDot3);
			context.SaveChanges();
		}
	}
}
