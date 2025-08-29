using BeauProject.Identity.IoC;
using BeauProject.Identity.MAUI.Shared.Services;
using BeauProject.Identity.MAUI.Web.Components;
using BeauProject.Identity.MAUI.Web.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

// Add device-specific services used by the BeauProject.Identity.MAUI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

#region IoC
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/"); // آدرس API 7127
});
// رجیستر کردن ApiAuthClient
builder.Services.AddScoped<AuthenticationService>();
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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(typeof(BeauProject.Identity.MAUI.Shared._Imports).Assembly);

app.Run();
