namespace CovidAnalysis.API.Middlewares
{
    public class RequestValidatorMiddleware
    {
		private readonly RequestDelegate _next;

		public RequestValidatorMiddleware(RequestDelegate next)
		{
			_next = next;
		}
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{//rapidapi
				var requestHeader = context.Request.Headers[""];
				await _next(context);
			}
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
