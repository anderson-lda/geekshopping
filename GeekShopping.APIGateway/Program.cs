using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", op =>
                {
                    op.Authority = "https://localhost:4435/";
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                    };
                });

builder.Services.AddOcelot();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOcelot();

app.Run();
