namespace CustomHeader.Middlewares;

public class AddCustomRequestHeaderMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _headerName;
    private readonly string _headerValue;

    public AddCustomRequestHeaderMiddleware(RequestDelegate next, string headerName, string headerValue)
    {
        _next = next;
        _headerName = headerName;
        _headerValue = headerValue;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Request.Headers[_headerName] = _headerValue;
        await _next(context);
    }
}

public static class AddCustomRequestHeaderMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomRequestHeader(this IApplicationBuilder applicationBuilder, string headerName, string headerValue)
    {
        return applicationBuilder.UseMiddleware<AddCustomRequestHeaderMiddleware>(headerName, headerValue);
    }
}
