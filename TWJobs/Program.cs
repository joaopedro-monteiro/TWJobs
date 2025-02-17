using TWJobs.Core.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterDatabase();
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.RegisterMappers();
builder.Services.RegisterJobRequestValidator();
builder.Services.RegisterAssembler(); 
builder.Services.RegisterDocumentation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


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

app.RegisterMiddlewares();

app.Run();
