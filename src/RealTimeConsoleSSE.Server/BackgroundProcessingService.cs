namespace RealTimeConsoleSSE.Server;

public static class BackgroundProcessingService
{
    public record StatusUpdate(bool Error, string Message);
    public async static IAsyncEnumerable<StatusUpdate> StartProcessing()
    {
        for (int i = 1; i <= 5; i++)
        {
            await Task.Delay(2000);

            yield return i == 3
                ? new StatusUpdate(Error: true, Message: "Erro ao processar o passo 3.")
                : new StatusUpdate(Error: false, Message: $"Passo {i} concluído com sucesso.");
        }
    }
}
