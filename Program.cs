using Pedeai.App.Shared;
using Pedeai.App.Auth;
using Pedeai.App.Catalog;

var builder = WebApplication.CreateBuilder(args);

// Setup
builder.Services.AddControllers();

// Modules
builder.Services.AddJwtMiddleware(builder.Configuration);
builder.Services.AddDocumentationModule(builder.Configuration);
builder.Services.AddSharedModule(builder.Configuration);
builder.Services.AddAuthModule(builder.Configuration);
builder.Services.AddCatalogModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDocumentationUI();

// Configure the HTTP request pipeline.
if(app.Environment.IsProduction()) app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();