using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace EstudoEnvioEmail.Service
{
public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarEmailAsync(string paraEmail, string paraNome, string assunto, string corpoHtml)
    {
        // 1. Obter a Chave (do User Secrets ou appsettings.json)
        var apiKey = _configuration["SendGrid:ApiKey"];
        
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("A API Key do SendGrid não foi configurada.");
        }

        var client = new SendGridClient(apiKey);

        // 2. Definir o Remetente (DEVE ser o e-mail que você verificou no Passo 1)
        var from = new EmailAddress("ca22iojob@gmail.com", "Seu Nome (Remetente)");

        // 3. Definir o Destinatário
        var to = new EmailAddress(paraEmail, paraNome);

        // 4. Criar a Mensagem
        // MailHelper.CreateSingleEmail é a forma mais fácil
        var msg = MailHelper.CreateSingleEmail(
            from,
            to,
            assunto,
            corpoHtml, // O corpo pode ser texto puro
            corpoHtml  // Ou HTML, para e-mails mais ricos
        );

        // 5. Enviar o E-mail
        var response = await client.SendEmailAsync(msg);

        // 6. Verificar o Resultado
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("E-mail enviado com sucesso!");
        }
        else
        {
            Console.WriteLine($"Falha ao enviar e-mail: {response.StatusCode}");
            // Para debug, você pode ler o corpo da resposta
            string responseBody = await response.Body.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
}
    
}
