using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TesteSQLServer.Context;
using TesteSQLServer.Context.Interfaces;
using TesteSQLServer.Migrations;
using TesteSQLServer.Migrations.Interfaces;
using TesteSQLServer.Repositories;
using TesteSQLServer.Repositories.Favorites;
using TesteSQLServer.Repositories.Orders;
using TesteSQLServer.Repositories.Payments;
using TesteSQLServer.Repositories.Products;
using TesteSQLServer.Repositories.Users;
using TesteSQLServer.Services;
using TesteSQLServer.Services.Favorites;
using TesteSQLServer.Services.Orders;
using TesteSQLServer.Services.Payments;
using TesteSQLServer.Services.Products;
using TesteSQLServer.Services.Sessions;
using TesteSQLServer.Services.Users;
using TesteSQLServer.Services.Utils;
using TesteSQLServer.Services.Utils.Hash;
using TesteSQLServer.Services.Utils.Token;

namespace TesteSQLServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddSingleton<IConnection, DapperContext>();
            services.AddSingleton<IDatabase, Database>();

            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer()
                    .WithGlobalConnectionString(Configuration.GetConnectionString("SqlConnection"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

            services.AddScoped<IFavoritesRepository, FavoritesRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, HashService>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISessionsService, SessionsService>();
            services.AddScoped<IFavoritesService, FavoritesService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IPaymentsService, PaymentsService>();

            services.AddControllers();

            var key = Settings.SecretBytes();

            services.AddAuthentication(option => 
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteSQLServer", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteSQLServer v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
