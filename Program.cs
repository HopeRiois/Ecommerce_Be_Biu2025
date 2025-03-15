using ecommerce_biu.Data;
using ecommerce_biu.Repositories;
using ecommerce_biu.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

//Configure db
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))));

var encryption = new ecommerce_biu.Utils.Encryption(builder.Configuration["EncryptionSettings:Key"]!);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Global services
builder.Services.AddSingleton(encryption);

var app = builder.Build();

//Update db models
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Migrate db models
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
