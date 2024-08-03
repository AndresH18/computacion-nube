var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

// add blazor wasm files to project, under the /wasm path, this is set in the client project <StaticWebAssetBasePath>
app.UseBlazorFrameworkFiles("/wasm");
app.MapFallbackToFile("/wasm/{*path:nonfile}", "wasm/index.html");

app.Run();
