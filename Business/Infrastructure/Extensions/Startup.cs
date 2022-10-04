using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace EmiGreat.Business.Infrastructure.Extensions
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, string environmentName, Profile webMapperProfile)
		{
            Data.Infrastructure.Extensions.Startup.ConfigureServices(services, environmentName);

			// services.AddScoped<IAuthenticationService, AuthenticationService>();

			// var mapperConfiguration = new MapperConfiguration(mc =>
			// {
			// 	mc.AddProfile(webMapperProfile);
			// 	mc.AddProfile(new BusinessMapperProfile());
			// });

			//IMapper mapper = mapperConfiguration.CreateMapper();
			//services.AddSingleton(mapper);

			//services.AddLocalization(options => options.ResourcesPath = "Infrastructure/Resources");

		}
    }
}