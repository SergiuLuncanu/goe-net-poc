using Application.Common.Interfaces;
using MediatR;

namespace Application.Contact.Commands
{
    public class ContactCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Content { get; set; }
    }

    public class ContactCommandHandler : IRequestHandler<ContactCommand,bool>
    {
        private readonly IMailSender _mailSender;

        public ContactCommandHandler(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public async Task<bool> Handle(ContactCommand request, CancellationToken cancellationToken)
        {
            return await _mailSender.SendContactEmail(request.Email, request.Content);
        }
    }
}
