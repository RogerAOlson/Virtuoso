using ContactManager.Models;
using ContactManagerRepositoryDict.Models;

var builder = WebApplication.CreateBuilder(args);


var configurationManager = new ContactManagerConfiguration();
builder.Services.AddSingleton<IContactManagerRepositoryConfiguration>(configurationManager);

ContactManager.ServiceCollectionExtensions.RegisterContactManager(builder.Services);
MarketingWeb.ServiceCollectionExtensions.RegisterMarketingWeb(builder.Services);
if (!builder.Environment.IsDevelopment())
{
    ContactManagerRepositoryDB.ServiceCollectionExtensions.RegisterContactManagerRepository(builder.Services);
    configurationManager.ConnectionString = builder.Configuration.GetValue<string>("ContactManagerRepositoryDB:ConnectionString");
}
else
{
    ContactManagerRepositoryDict.ServiceCollectionExtensions.RegisterContactManagerRepository(builder.Services);
}

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