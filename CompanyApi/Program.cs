using CompanyApi.Context;
using CompanyApi.Interface;
using CompanyApi.MiddleWare;
using CompanyApi.Repositery;
using CompanyApi_BAL.Services;
using CompanyApi_BAL.Services.IServices;
using CompanyApi_DAL.Interface;
using CompanyApi_DAL.Repositery;
using EmployeeApi.Model;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace CompanyApi
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CompanyContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(x =>
                {
                    x.ImplicitlyValidateChildProperties = true;
                    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });

            builder.Services.AddOData();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeAddressService, EmployeeAddressService>();
            builder.Services.AddScoped<IEmployeeRepositery, EmployeeRepositery>();
            builder.Services.AddScoped<IDepartmentRepositery, DepartmentRepositery>();
            builder.Services.AddScoped<IEmployeeAddressRepositery,EmployeeAddressRepositery>(); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //jwt authentication configuartion
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                });

                opt.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            //automapper configuation
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //serilog configuration
            Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
            builder.Host.UseSerilog(((ctx, lc) => lc

            .ReadFrom.Configuration(ctx.Configuration)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseClassWithNoImplementationMiddleware();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseUserNameMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
                endpoints.MapODataRoute("odata", " ", GetEdmModel());
            });
            app.Run();
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Employee>("Employee");
            modelBuilder.EntitySet<Department>("Department");
            modelBuilder.EntitySet<EmployeeAddress>("EmployeeAddress");
            modelBuilder.EntitySet<Project>("Project");
            modelBuilder.EntitySet<Team>("Team");
            return modelBuilder.GetEdmModel();
        }
    }
}