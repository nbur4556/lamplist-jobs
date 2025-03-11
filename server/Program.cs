using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using server.Db;
using server.Models;
using server.Services;

var builder = WebApplication.CreateBuilder(args);
var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string>();
string? dbHost = builder.Configuration["PostgreSql:DbHost"];
string? dbDatabase = builder.Configuration["PostgreSql:DbDatabase"];
string? dbUser = builder.Configuration["PostgreSql:DbUser"];
string? dbPassword = builder.Configuration["PostgreSql:DbPassword"];
string? dbConnection = "Host=" + dbHost + "; Database=" + dbDatabase + "; Username=" + dbUser;

string allowOriginPolicyRef = "_allowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
  if (corsOrigins is null) { return; }
  options.AddPolicy(name: allowOriginPolicyRef, policy =>
    policy.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod()
  );
});
builder.Services.AddDbContext<DataContext>(options =>
  options.UseNpgsql($"{dbConnection}; Password={dbPassword}")
);
builder.Services.AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
{
  options.Password.RequireDigit = true;
  options.Password.RequiredLength = 12;
  options.Password.RequireNonAlphanumeric = true;
  options.Password.RequireUppercase = true;
  options.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<DataContext>();
builder.Services.AddAuthentication(auth =>
{
  auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  string? authKey = builder.Configuration["AuthSettings:Key"];
  if (authKey != null)
  {
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidAudience = builder.Configuration["AuthSettings:Audience"],
      ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
      RequireExpirationTime = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authKey)),
      ValidateIssuerSigningKey = true,
    };
  }
});

// Add Scopes
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Add Logging
builder.Services.AddLogging(builder => builder.AddConsole());

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

app.UseCors(allowOriginPolicyRef);

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
  ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
