var builder = WebApplication.CreateBuilder(args);

String allowOriginPolicyRef = "_allowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: allowOriginPolicyRef, policy =>
    //TODO: Use environment to determine origin/s to add
    policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()
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
