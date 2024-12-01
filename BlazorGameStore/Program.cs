using BlazorGameStore.Clients;
using BlazorGameStore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var api = builder.Configuration["ApiUrl"] ?? throw new Exception("Setting null : ApiUrl");
builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(api));
builder.Services.AddHttpClient<GenreClient>(client => client.BaseAddress = new Uri(api));


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
