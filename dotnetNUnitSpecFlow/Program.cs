using Manager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=BeautyExamenDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true"));
builder.Services.AddMemoryCache();

var app = builder.Build();


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
