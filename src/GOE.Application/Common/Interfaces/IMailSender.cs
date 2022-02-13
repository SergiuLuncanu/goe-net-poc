namespace GOE.Application.Common.Interfaces
{
    public interface IMailSender
    {
        Task<bool> SendConfirmationEmail(string emailTo, string token);
        Task<bool> SendContactEmail(string from, string message);
    }
}
