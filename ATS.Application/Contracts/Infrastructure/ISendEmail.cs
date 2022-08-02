using ATS.Application.Models;
namespace ATS.Application.Contracts.Infrastructure
{
    public interface ISendEmail
    {
        Task<bool> SendEmail(MailRequest mailRequest);
    }
}
