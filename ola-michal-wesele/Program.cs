using Microsoft.Extensions.FileProviders;
using ola_michal_wesele.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

if (!app.Environment.IsDevelopment())
{
	app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseAntiforgery();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(Directory.GetCurrentDirectory(), "StaticRes")),
	RequestPath = "/StaticRes"
});
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();