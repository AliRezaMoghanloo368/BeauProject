using BeauProject.Identity.IoC;
using BeauProject.UI.App.MAUI.Shared.Services;
using BeauProject.UI.App.MAUI.Shared.Components;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

#region IoC
builder.Services.AddHttpClient("API/Users", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});
builder.Services.AddHttpClient("API/Files", client =>
{
    client.BaseAddress = new Uri("http://localhost:5002/");
});

// رجیستر کردن ApiAuthClient
builder.Services.AddScoped<AuthService>();

// جهت مدارک و عکسها و فایلهای متنوع
builder.Services.AddScoped<FilesService>();

// برای LocalStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.RegisterServices(builder.Configuration); //in dependency container class

builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapStaticAssets();

app.MapRazorComponents<App>();

app.Run();
