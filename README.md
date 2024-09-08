# Real Time Console SSE

Este é um aplicativo de console desenvolvido em C# e .NET 8, utilizando Server-Sent Events (SSE) para comunicação em tempo real entre cliente e servidor.

![image](https://github.com/user-attachments/assets/61710f23-8105-4127-9d03-9c520b3bcffc)


## Conceitos Aplicados

- **Server-Sent Events (SSE)**: Protocolo que permite ao servidor enviar atualizações de forma unidirecional para o cliente, mantendo uma conexão persistente. Utilizado aqui para enviar eventos e atualizações de status em tempo real para o cliente console.

- **Eventos em Tempo Real**: Técnica que permite a comunicação contínua do servidor para o cliente, ideal para aplicações que precisam enviar atualizações em tempo real.

## Estrutura do Projeto

- **Cliente (RealTimeSSE.Client)**:
  - Conecta-se ao servidor SSE e recebe eventos de status.
  - Utiliza `HttpClient` para estabelecer a conexão com o endpoint SSE.
  - Processa e exibe eventos recebidos em tempo real no console.

- **Servidor (RealTimeSSE.Server)**:
  - Expõe um endpoint SSE que transmite eventos de status para os clientes conectados.
  - **Atualizações de Status**: Gera e envia eventos de status em tempo real utilizando a técnica de streaming de eventos.
  - Utiliza `HttpContext` para gerenciar a resposta SSE e enviar eventos para o cliente.

## Como Executar

1. **Execute o Servidor**:
   - Navegue até o diretório do servidor e execute o comando:
     ```bash
     make server
     ```

2. **Execute o Cliente**:
   - Navegue até o diretório do cliente e execute o comando:
     ```bash
     make client
     ```

3. **Interaja**:
   - O cliente irá se conectar ao servidor SSE e começar a receber eventos.
   - Veja as atualizações e eventos recebidos no console.

## Dependências

- .NET 8

## Links Relacionados

https://en.wikipedia.org/wiki/Server-sent_events </br>
https://marcdias.com.br/server-sent-events/#definicao_de_sse </br>

</br>
