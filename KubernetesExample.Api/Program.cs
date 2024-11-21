var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

/* Deploy to kubernetes
 1 -- Add docker support to the project
 2 - in terminal =>
 (docker login into your account)
 (cd into project directory)
 3 - docker build -t <tag> .
 4 - docker push <tag>
 5 -- (create deploy.yml with config)

 6 - kubectl apply -f .\de
 */