namespace EstudoEnvioEmail.Service;

public interface IEmailService
{
    Task EnviarEmailAsync(string paraEmail, string paraNome, string assunto, string corpoHtml);
}