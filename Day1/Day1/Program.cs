var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "K23CNT1 Nguyen Ngoc Hieu");

app.Run();
