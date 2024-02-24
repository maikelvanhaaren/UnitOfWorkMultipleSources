namespace Example.Enlistments.Email;

public interface IEmailApi
{
    Task SendEmailAsync(string to, string subject, string body);
    Task ThrowExceptionSendEmailAsync(string to, string subject, string body);
}