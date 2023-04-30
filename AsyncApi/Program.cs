var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=RequestDb.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("api/v1/products", async (AppDbContext context, ListingRequest? request) =>
{
    if (request is null)
        return Results.BadRequest();

    request.RequestStatus = "ACCEPT";
    request.EstimatedCompletionTime = DateTime.UtcNow.AddMinutes(5).ToString(CultureInfo.InvariantCulture);

    await context.ListingRequests.AddAsync(request);
    await context.SaveChangesAsync();

    return Results.Accepted($"api/v1/productStatus/{request.RequestId}", request);
});

app.MapGet("api/v1/productStatus/{requestId}", async (AppDbContext context, string requestId) =>
{
    var request = await context.ListingRequests.FirstOrDefaultAsync(r => r.RequestId == requestId);

    if (request is null)
        return Results.NotFound();

    var status = new ListingStatus
    {
        RequestStatus = request.RequestStatus,
        ResourceUrl = string.Empty
    };

    if (request.RequestStatus!.ToUpper(CultureInfo.InvariantCulture) == "COMPLETE")
    {
        status.ResourceUrl = $"api/v1/products/{Guid.NewGuid().ToString()}";
        return Results.Redirect("https://localhost:5126/" + status.ResourceUrl);
    }

    status.EstimatedCompletionTime = DateTime.UtcNow.AddMinutes(15).ToString(CultureInfo.InvariantCulture);

    return Results.Ok(status);
});

// check the status and return from there
app.MapGet("api/v1/products/{requestId}", async (string requestId) => Results.Ok("todo"));

app.Run();