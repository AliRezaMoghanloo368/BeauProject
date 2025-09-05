using BeauProject.Identity.IoC;
using BeauProject.Presentation.Blazor.Components;
using BeauProject.Presentation.Blazor.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

#region IoC
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/"); // آدرس API 7127
});

// رجیستر کردن ApiAuthClient
builder.Services.AddScoped<AuthService>();

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
