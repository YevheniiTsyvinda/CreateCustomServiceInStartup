using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class ConfigMiddleware{
    private readonly RequestDelegate _next;
    public ConfigMiddleware (RequestDelegate next, IConfiguration config ){
        _next = next;
        AppConfiguration = config;
    }

    public IConfiguration AppConfiguration {get;set;}

    public async Task InvokeAsync(HttpContext context){
        await context.Response.WriteAsync($"name: {AppConfiguration["name"]} age: {AppConfiguration["age"]}");
    }
}