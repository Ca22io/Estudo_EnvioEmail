# 📧 Estudo: Envio de E-mail com C# e SendGrid

Este é um projeto de estudo focado em demonstrar a integração de um serviço de API de terceiros (SendGrid) em uma aplicação C# .NET moderna.

O projeto é um **Console App** que utiliza o *Generic Host* do .NET para configurar:
* Injeção de Dependência (DI)
* Gerenciamento de Configuração (`IConfiguration`)
* Leitura segura de chaves de API (User Secrets)

---

## 🚀 Conceitos e Habilidades Demonstradas

| Conceito | Descrição |
| :--- | :--- |
| **Abstração (POO)** | O `IEmailService` define um contrato, permitindo que a implementação (`SendGridEmailService`) seja trocada facilmente. |
| **Injeção de Dependência** | O `IEmailService` e o `IConfiguration` são injetados em tempo de execução, desacoplando as classes. |
| **Gerenciamento de Configuração** | O `IConfiguration` é usado para ler configurações de fontes externas (como User Secrets). |
| **Segurança de API Key** | A chave do SendGrid é armazenada com segurança usando o **`dotnet user-secrets`**, garantindo que nenhum dado sensível vaze para o repositório. |
| **Integração de SDK de Terceiros** | Uso do pacote `SendGrid` oficial para construir e enviar mensagens de e-mail. |
| **Programação Assíncrona** | Uso de `async/await` para enviar o e-mail sem bloquear a thread principal. |

---

## ⚙️ Configuração Rápida (Para Rodar)

Este projeto utiliza o `dotnet user-secrets` para armazenar a chave da API do SendGrid de forma segura.

### 1. Requisitos

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (ou superior)
* Uma conta SendGrid (mesmo que seja o plano gratuito)

### 2. Passos para Configurar

1.  Clone o repositório:
    ```bash
    git clone https://github.com/Ca22io/Estudo_EnvioEmail
    ```

2.  Navegue até a pasta do projeto:
    ```bash
    cd Estudo_EnvioEmail
    ```

3.  Inicialize o User Secrets (Cofre de Segredos):
    ```bash
    dotnet user-secrets init
    ```

4.  Armazene sua chave de API do SendGrid (obtida no painel do SendGrid):
    ```bash
    dotnet user-secrets set "SendGrid:ApiKey" "SUA_CHAVE_API_AQUI"
    ```

5.  Verifique o E-mail Remetente:
    Abra o arquivo `Service/EmailService.cs` e altere o e-mail do remetente (`from`) para o e-mail que você verificou na sua conta SendGrid.

---

## ▶️ Como Executar

Após configurar a API Key, basta executar a aplicação. O `Program.cs` está configurado para injetar o serviço e disparar um e-mail de teste.

```bash
dotnet run
```

## ❗️ Nota Importante (Status do Projeto)
A conta SendGrid gratuita associada a este estudo pode ter atingido o limite de envios diário/mensal.

Se você executar o projeto e receber um erro 401 Unauthorized com a mensagem Maximum credits exceeded (Créditos máximos excedidos), isso é um SUCESSO!

Este erro confirma que o código C#, a leitura da API Key e a comunicação com a API do SendGrid estão funcionando perfeitamente, e a falha ocorreu apenas por limitação de cota.
