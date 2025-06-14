using RTSP_Webcam_Server.Services;
using VisioForge.Core;

var builder = WebApplication.CreateBuilder(args);

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
