var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var services = builder.Services;

services.AddControllers();
var sqlbuilder = new NpgsqlConnectionStringBuilder(
    config.GetConnectionString("BooksConnection"))
{
    Username = config["DbUser"],
    Password = config["DbPassword"]
};

var connection = sqlbuilder.ConnectionString;
services.AddDbContext<BookContext>(options => options.UseNpgsql(connection));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();