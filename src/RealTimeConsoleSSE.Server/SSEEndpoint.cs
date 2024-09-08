namespace RealTimeConsoleSSE.Server;

public static class SSEEndpoint
{
    public static void MapSSEEndpoint(this IEndpointRouteBuilder endpoint) => endpoint.MapGet("/events", HandleSSEEndpoint);
    private static async void HandleSSEEndpoint(HttpContext context)
    {
        context.Response.Headers.Append("Content-Type", "text/event-stream");

        await context.Response.WriteAsync("data: Conexão iniciada \n\n");
        await context.Response.Body.FlushAsync();

        var processingStatus = BackgroundProcessingService.StartProcessing();

        await foreach (var statusUpdate in processingStatus)
        {
            if (statusUpdate.Error)
            {
                await context.Response.WriteAsync($"event: error\n");
                await context.Response.WriteAsync($"data: {statusUpdate.Message} \n\n");
            }
            else
            {
                await context.Response.WriteAsync($"data: {statusUpdate.Message} \n\n");
            }
            await context.Response.Body.FlushAsync();
        }

        await context.Response.WriteAsync("data: Processamento concluído\n\n");
        await context.Response.Body.FlushAsync();
    }
}