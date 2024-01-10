using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration["ConnectionStrings:EntitiesConnection"] ?? "";
builder.Services.AddDbContext<DBContext>(x =>
{
    x.UseSqlServer(connection);
});


builder.Services.DIScopes();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Allow cors
builder.Services.AddCors(x => x.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Connexcel-BE", Version = "v1" });

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
             new OpenApiSecurityScheme
             {
                  Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                  }
             },
         new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JsonWebTokenKeys:IssuerSigningKey").Value);
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JsonWebTokenKeys:IssuerSigningKey").Value)),
        ValidIssuer = builder.Configuration.GetSection("JsonWebTokenKeys:ValidIssuer").Value,
        ValidAudience = builder.Configuration.GetSection("JsonWebTokenKeys:ValidAudience").Value,
        ClockSkew = TimeSpan.FromMinutes(Convert.ToInt32(builder.Configuration.GetSection("JsonWebTokenKeys:TokenExpiryMin").Value)),
    };
    x.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();


app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(x => x.DefaultModelsExpandDepth(-1));


app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();
