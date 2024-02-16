using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Resify.Services.ReservationAPI.Messaging;

namespace Resify.Services.AuthAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
	private static IAzureServiceBusConsumer ServiceBusConsumer { get; set; }

	public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
	{
		var settingSection = builder.Configuration.GetSection("ApiSettings:JwtOptions");

		var secret = settingSection.GetValue<string>("Secret");
		var issuer = settingSection.GetValue<string>("Issuer");
		var audience = settingSection.GetValue<string>("Audience");

		var key = Encoding.ASCII.GetBytes(secret);

		builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidIssuer = issuer,
					ValidateAudience = true,
					ValidAudience = audience
				};

				options.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						if (context.Request.Cookies.TryGetValue("jwt", out var token)) context.Token = token;
						return Task.CompletedTask;
					}
				};
			});

		return builder;
	}

	public static IApplicationBuilder UseAzureServiceBusConsumer(this IApplicationBuilder app)
	{
		ServiceBusConsumer = app.ApplicationServices.GetService<IAzureServiceBusConsumer>();
		var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();

		hostApplicationLife.ApplicationStarted.Register(OnStart);
		hostApplicationLife.ApplicationStopping.Register(OnStop);

		return app;
	}

	private static void OnStop()
	{
		//ServiceBusConsumer.Stop();
	}

	private static void OnStart()
	{
		//ServiceBusConsumer.Start();
	}
}