namespace API1._0;

public class MyMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Before Controller - req received");
        await next(context);
        Console.WriteLine("After Controller - req received");
    }
}