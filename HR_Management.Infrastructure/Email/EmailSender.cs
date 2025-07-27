using HR_Management.Application.Contracts.Infrastructure;

namespace HR_Management.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        public Task<bool> SendEmail(Application.Models.Email email)
        {
            // todo: send email method

            throw new NotImplementedException();
        }
    }
}
