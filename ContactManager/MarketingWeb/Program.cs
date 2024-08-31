
var builder = WebApplication.CreateBuilder(args);

ContactManager.ServiceCollectionExtensions.RegisterContactManager(builder.Services);
Repository.ServiceCollectionExtensions.RegisterContactManagerRepository(builder.Services);
MarketingWeb.ServiceCollectionExtensions.RegisterMarketingWeb(builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }