namespace ExInspectorBackend.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private const string XMID = "XMid";
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(XMID, out var extractedXMid))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(string.Empty);
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var xMid = appSettings.GetValue<string>(XMID);

            var xMid1 = FormatAPI.FormatString(xMid);

            if (!xMid1.Equals(extractedXMid))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(string.Empty);
                return;
            }

            await _next(context);
        }
    }
}
