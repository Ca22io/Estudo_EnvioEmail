using EstudoEnvioEmail.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Configura o "Host" (que gerencia DI, Configuração, etc.)
var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration((hostingContext, config) =>
    {
            // Isso garante que os segredos sejam lidos mesmo se o ambiente 
            // não for "Development". Usa a classe Program como âncora.
        config.AddUserSecrets<Program>(); 
    });


builder.ConfigureServices((hostContext, services) =>
    {
        services.AddTransient<IEmailService, EmailService>();
    });

var host = builder.Build();

// Pede ao contêiner de DI uma instância do IEmailService
// O contêiner sabe que deve criar um SendGridEmailService
// e injetar IConfiguration nele automaticamente.
var emailService = host.Services.GetRequiredService<IEmailService>();

// Chama o método
await emailService.EnviarEmailAsync(
    "ca22iojob@gmail.com",
    "Nome Destinatário",
    "Meu Primeiro E-mail SendGrid!",
    "<strong>Olá!</strong> Este é um e-mail de teste enviado via C# e SendGrid."
    );