using ContactManager.Models;
using ContactManagerRepositoryDB.Models;

var builder = WebApplication.CreateBuilder(args);



ContactManager.ServiceCollectionExtensions.RegisterContactManager(builder.Services);
MarketingWeb.ServiceCollectionExtensions.RegisterMarketingWeb(builder.Services);
if (!builder.Environment.IsDevelopment())
{
    ContactManagerRepositoryDB.ServiceCollectionExtensions.RegisterContactManagerRepository(builder.Services);

    var configurationManager = new ContactManagerRepositoryConfiguration();
    configurationManager.ContactManagerRepositoryConnectionString = builder.Configuration.GetValue<string>("ContactManagerRepositoryDB:ConnectionString");
    builder.Services.AddSingleton<IContactManagerRepositoryConfiguration>(configurationManager);
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