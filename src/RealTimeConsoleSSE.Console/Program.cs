

var httpClient = new HttpClient();
var sseUri = "http://localhost:8080/sse/events";

using (var request = new HttpRequestMessage(HttpMethod.Get, sseUri))
using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
{
    if (response.IsSuccessStatusCode)
    {
        using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);

        string? line = string.Empty;
        Console.WriteLine("Conectado ao servidor SSE. Aguardando eventos...");

        while (!reader.EndOfStream)
        {
            line = await reader.ReadLineAsync();

            if (!string.IsNullOrEmpty(line))
            {
                if (line.StartsWith("data: "))
                {
                    var eventData = line[6..]; // line.Substring(6); - range operator
                    Console.WriteLine($"Evento recebido: {eventData}");
                }
                else if (line.StartsWith("event: error"))
                {
                    Console.WriteLine("Erro recebido do servidor!");
                }
            }
        }
    }
    else
    {
        Console.WriteLine($"Falha ao conectar ao servidor SSE: {response.StatusCode}");
    }
}

Console.WriteLine("Conexão encerrada. Pressione qualquer tecla para sair...");
Console.ReadKey();