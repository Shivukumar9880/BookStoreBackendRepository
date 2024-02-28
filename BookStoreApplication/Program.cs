using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System.Text;

namespace BookStoreApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();



            //swagger authorization code
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{}
    }
});
            });


            //regestraing the Interfaces and Services
            builder.Services.AddTransient<IUserBusiness, UserBusiness>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();

            builder.Services.AddTransient<IAddressBusiness,AddressBusiness>();
            builder.Services.AddTransient<IAddresseRepo,AddressRepo>();

            builder.Services.AddTransient<IBookBusiness, BookBusiness>();
            builder.Services.AddTransient<IBookRepo, BookRepo>();


            builder.Services.AddTransient<ICartBusiness,CartBusiness>();
            builder.Services.AddTransient<ICartRepo, CartRepo>();

            builder.Services.AddTransient<IOrderBusiness, OrderBusiness>();
            builder.Services.AddTransient<IOrderRepo, OrderRepo>();

            builder.Services.AddTransient<IReviewBusinesscs, ReviewBusiness>();
            builder.Services.AddTransient<IReviewRepo, ReviewRepo>();

            builder.Services.AddTransient<IwishListBusiness, WishListBusiness>();
            builder.Services.AddTransient<IwishListRepo, WishListRepo>();




            //jwt token generatator registraion code step-1
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });



            //cross vlidate from angular for AllowOrigin"
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)));
            });

            var app = builder.Build();


            app.UseCors(builder => builder.WithOrigins("*")/*.AllowAnyOrigin()*/.AllowAnyHeader().AllowAnyMethod());


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            app.UseCors("AllowOrigin");
        }
    }
}
