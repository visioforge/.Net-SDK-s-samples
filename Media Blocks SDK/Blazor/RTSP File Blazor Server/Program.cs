using RTSP_File_Server.Services;
using VisioForge.Core;

#if __MACOS__
// A macOS exe has an AppKit context with no run loop; continuations posted to it never run.
System.Threading.SynchronizationContext.SetSynchronizationContext(null);

// The bundle root holds no web files; the static assets are copied into Contents/Resources.
var appRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory, "..", "Resources"));
var builder = WebApplication.CreateBuilder(new WebApplicationOptions { Args = args, ContentRootPath = appRoot });
#else
var builder = WebApplication.CreateBuilder(args);
#endif

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add VisioForge service
builder.Services.AddSingleton<VisioForgeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Initialize VisioForge SDK
var visioForgeService = app.Services.GetRequiredService<VisioForgeService>();
await visioForgeService.InitializeAsync();

app.Run();
