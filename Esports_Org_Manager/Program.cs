using Esports_Org_Manager.Components;
using Esports_Org_Manager.Data;
using Esports_Org_Manager.Entities;
using Esports_Org_Manager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ListPasser>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<TourneyService>();

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

app.Run();
