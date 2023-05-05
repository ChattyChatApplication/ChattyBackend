using Api.Configs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAllDependencies(builder.Configuration);

// TODO create AppConfig and put all these shits below inside
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