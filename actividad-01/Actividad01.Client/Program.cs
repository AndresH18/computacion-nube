using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Actividad01.Client;
using Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Logging.SetMinimumLevel(LogLevel.Information);

// builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// builder.Services.AddSingleton<IStudentService, InmemoryStudentService>();
builder.Services.AddHttpClient<IStudentService, StudentService>(client =>
{
    var urls = builder.Configuration.GetRequiredSection(StudentService.ServiceKey);
    var url = urls["http"]!;
    client.BaseAddress = new Uri(url);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
await builder.Build().RunAsync();