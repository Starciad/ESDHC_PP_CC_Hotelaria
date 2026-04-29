var builder = WebApplication.CreateBuilder(args);

// ESSENCIAL
builder.Services.AddControllers();

// opcional swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// swagger
app.UseSwagger();
app.UseSwaggerUI();

// ESSENCIAL
app.MapControllers();

app.Run();