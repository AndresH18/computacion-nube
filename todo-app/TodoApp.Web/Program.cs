var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

#if WASM_HOST
// add this to enable route to static files for webassembly that normally are located on "/". Basically it allows delivering static files located in "/wasm"
app.UseStaticFiles("/wasm");
// add blazor wasm files to project, under the /wasm path, this is set in the client project <StaticWebAssetBasePath>
app.UseBlazorFrameworkFiles("/wasm");
app.MapFallbackToFile("/wasm/{*path:nonfile}", "wasm/index.html");
#endif

app.Run();