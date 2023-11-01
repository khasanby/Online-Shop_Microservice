using Ordering.Application.Models;

namespace Ordering.Application.Contracts.Infrastucture
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(Email email);
    }
}
