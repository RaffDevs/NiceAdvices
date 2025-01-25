using MudBlazor.Services;
using NiceAdvices.CrossCutting.IoC;
using NiceAdvices.Web.Components;
using NiceAdvices.Web.Components.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["BaseAddress"])
});
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAdviceHttpClient(builder.Configuration);
builder.Services.AddTranslatorHttpClient(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddMediator();

builder.Services.AddScoped<AdviceState>();



builder.Services.AddMudServices();

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

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();