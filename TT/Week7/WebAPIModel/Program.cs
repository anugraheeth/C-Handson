
using WebAPIModel.Repositories;

namespace WebAPIModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            //if you didn't use this
            // public ProductController()
            //{
            //    _productRepository = new ProductRepository(); 
            //}
            // you need to register the repository in the service container so that it can be injected into the controller.
            //builder.Services.AddScoped<IProductRepo, ProductRepo>();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
