using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QlyPhatTu.Helper;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

//builder.Services.Configure<Appsettings>(builder.Configuration.GetSection("Appsettings"));

var secretKeyBytes = Encoding.UTF8.GetBytes(builder.Configuration["Appsettings:SecretKey"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Tu Cap Token
        ValidateIssuer = false,
        ValidateAudience = false,

        //Ky vao Token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
        ClockSkew = TimeSpan.Zero
    };
});

// Tạo phân quyền cho API
builder.Services.AddAuthorization(option =>
{
    //option.AddPolicy("ADMINANDMEMBER", policy =>
    //    policy.RequireRole(
    //         "ADMIN", "MEMBER" 
    //        )
    //);
    option.AddPolicy("ADMINANDMEMBER", policy =>
        policy.RequireClaim(ClaimTypes.Role,
             "ADMIN", "MEMBER"
            )
    );
    option.AddPolicy("MEMBER", policy => policy.RequireClaim(
        ClaimTypes.Role, "MEMBER"
        ));
    option.AddPolicy("ADMIN", policy => policy.RequireClaim(
     ClaimTypes.Role, "ADMIN"
     ));
    option.AddPolicy("TRUTRI", policy =>
    policy.RequireClaim(ClaimTypes.Role, "TRUTRI")
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
