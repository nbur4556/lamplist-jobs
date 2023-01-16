var builder = WebApplication.CreateBuilder(args);
var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<String[]>();

String allowOriginPolicyRef = "_allowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
  if (corsOrigins is null) { return; }
  options.AddPolicy(name: allowOriginPolicyRef, policy =>
    policy.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod()
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

app.UseCors(allowOriginPolicyRef);

app.UseAuthorization();

app.MapControllers();

app.Run();
