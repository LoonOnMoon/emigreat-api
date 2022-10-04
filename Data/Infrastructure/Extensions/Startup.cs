using System.Text;
using EmiGreat.Data.Models.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EmiGreat.Data.Infrastructure.Extensions
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, string EnvironmentName)
		{
			
			var configuration = new ConfigurationBuilder()
				.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
        		.AddJsonFile(path: $"appsettings.{EnvironmentName}.json", optional: true)
				.Build();
            services.AddSingleton(configuration);

            // TODO: Add config validation
            string jwtSecret = configuration["JWT:Secret"] ?? string.Empty;

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateAudience = true,
						ValidateIssuer = true,
						ValidAudience = configuration["JWT:ValidAudience"],
						ValidIssuer = configuration["JWT:ValidIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
					};
					// options.Events = new JwtBearerEvents
					// {
					// 	OnAuthenticationFailed = context => {
					// 		Console.WriteLine(context.Exception);
					// 		return Task.CompletedTask;
					// 	}
					// };
				});

			services.AddDbContext<EmiGreatContext>(options =>
				options.UseNpgsql(
					configuration.GetConnectionString("PostgresqlEmiGreat")));

			services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddRoles<Role>()
				.AddUserManager<UserManager<User>>()
				.AddRoleManager<RoleManager<Role>>()
				.AddEntityFrameworkStores<EmiGreatContext>()
				.AddDefaultTokenProviders();
			
		}
    }
}