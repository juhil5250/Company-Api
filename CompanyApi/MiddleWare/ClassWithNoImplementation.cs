namespace CompanyApi.MiddleWare
{
    public class ClassWithNoImplementation : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello World From Custom MiddleWare....");
        }   
    }

    public static class ClassWithNoImplementationExtension
    {
        public static IApplicationBuilder UseClassWithNoImplementationMiddleware(this IApplicationBuilder Builder)
        {
            return Builder.UseMiddleware<ClassWithNoImplementation>();
        }
    }


}
