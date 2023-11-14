using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ODataRD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(g =>
            {
                g.EnableEndpointRouting = false;
            }).AddOData(opt =>
            {
                var batchHandler = new DefaultODataBatchHandler();
                opt.AddRouteComponents("api/v1", GetEdmModels(), batchHandler);
                opt.Count().Select().Filter().OrderBy().Expand().SetMaxTop(int.MaxValue);
                opt.EnableQueryFeatures(int.MaxValue);
                opt.EnableAttributeRouting = false;
            }).AddJsonOptions(g =>
            {
                g.AllowInputFormatterExceptionMessages = true;
                // g.JsonSerializerOptions.PropertyNamingPolicy = null;
            }); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseODataRouteDebug();
            app.UseODataRouteDebug();
            app.UseHttpsRedirection();
            app.UseODataBatching();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }

        public static IEdmModel GetEdmModels()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<WeatherForecast>(nameof(WeatherForecast));
            return builder.GetEdmModel();
        }
    }
}