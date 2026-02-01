var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Aggiungi servizi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // serve per Swagger
builder.Services.AddSwaggerGen();           // sostituisce AddOpenApi()

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                       // sostituisce MapOpenApi()
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
