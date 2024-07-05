using api_form.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura la clave de API de OpenAI desde una variable de entorno
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

// Add services to the container.
builder.Services.AddSingleton(new ChatGPTService(apiKey));
builder.Services.AddControllers();
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
