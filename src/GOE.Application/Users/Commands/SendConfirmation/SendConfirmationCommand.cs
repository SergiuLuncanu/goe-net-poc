using GOE.Application.Common.Interfaces;
using GOE.Domain.Consts;
using GOE.Domain.Entities;
using MediatR;

namespace GOE.Application.Users.Commands.SendConfirmation
{
    public class SendConfirmationCommand : IRequest<bool>
    {
        public string AppUrl { get; set; }
        public User User { get; set; }
    }

    public class SendConfirmationCommandHandler : IRequestHandler<SendConfirmationCommand, bool>
    {
        private readonly IMailSender _mailSender;
        private readonly IJwtService _jwtService;

        public SendConfirmationCommandHandler(
            IMailSender mailSender,
            IJwtService jwtService)
        {
            _mailSender = mailSender;
            _jwtService = jwtService;
        }


        public async Task<bool> Handle(SendConfirmationCommand request, CancellationToken cancellationToken)
        {
            if (request.User.Role != UserRoles.Guest)
            {
                return false;
            }
            var token = _jwtService.GenerateJwt(request.User);
            return await _mailSender.SendConfirmationEmail(request.User.Email, request.AppUrl + token);
        }
    }
}
