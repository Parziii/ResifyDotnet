﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Resify.Services.TablesAPI.Extensions
{
	public static class WebApplicationBuilderExtensions
	{
		public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
		{
			var settingSection = builder.Configuration.GetSection("ApiSettings");

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
							if (context.Request.Cookies.TryGetValue("jwt", out string token))
							{
								context.Token = token;
							}
							return Task.CompletedTask;
						}
					};
				});

			return builder;
		}
	}
}
