using Blog.WebMvc.Models;

namespace Blog.WebMvc.Services;

public interface IEmailSender
{
    Task SendEmail(EmailData emailData);
}
