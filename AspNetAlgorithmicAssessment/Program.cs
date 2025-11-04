using AspNetAlgorithmicAssessment.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Register the starter notification service. Candidates may improve/replace it.
builder.Services.AddSingleton<INotificationService, InMemoryNotificationService>();
var app = builder.Build();
app.MapControllers();
app.Run();
