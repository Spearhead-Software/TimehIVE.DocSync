using App.TransferredFiles;
using Infra.Common.Persistence;
using Infra.TransferredFiles;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransferredFileRepo, TransferredFilesRepo>();
builder.Services.AddScoped<ITransferredFileService, TransferredFileService>();
DatabaseSettings dbSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>()!;


NpgsqlConnectionStringBuilder dbBuilder = new NpgsqlConnectionStringBuilder()
{
    Host = dbSettings.Host,
    Port = dbSettings.Port,
    Username = dbSettings.Username,
    Password = dbSettings.Password,
    Database = dbSettings.Database,
};

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseNpgsql(dbBuilder.ConnectionString).UseSnakeCaseNamingConvention();
});

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
