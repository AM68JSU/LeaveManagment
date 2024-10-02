using Infrastructure.Identity.Context;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using LeaveManagment.Application.Contracts.Identity;
using LeaveManagment.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace LeaveManagment.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //services.AddDbContext<LeaveManagmentIdentityDbContext>(option =>
            //{
            //    option.UseSqlServer(configuration.GetConnectionString("LeaveManagmentIdentityConnectionString")
            //        , b => { b.MigrationsAssembly(typeof(LeaveManagmentIdentityDbContext).Assembly.FullName); b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
       
            //    });


            services.AddDbContext<LeaveManagmentIdentityDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("LeaveManagmentIdentityConnectionString")
                    , b => b.MigrationsAssembly(typeof(LeaveManagmentIdentityDbContext).Assembly.FullName));

            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<LeaveManagmentIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            //  services.AddTransient<IUserService, UserService>();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters { 
                    ValidateIssuerSigningKey=true,
                    ValidateAudience=true,
                    ValidateIssuer=true,
                    ValidateLifetime=true,
                    ClockSkew=System.TimeSpan.Zero,
                    ValidIssuer=configuration["JwtSettings:Issuer"],
                    ValidAudience= configuration["JwtSettings:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))

                };
            });

            return services;
        }
    }
}
