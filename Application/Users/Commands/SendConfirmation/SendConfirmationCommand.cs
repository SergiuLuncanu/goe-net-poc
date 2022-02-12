using Application.Common.Interfaces;
using Domain.Consts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.SendConfirmation
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
            if(request.User.Role != UserRoles.Guest)
            {
                return false;
            }
            var token = _jwtService.GenerateJwt(request.User);
            return await _mailSender.SendConfirmationEmail(request.User.Email, request.AppUrl + token);
        }
    }
}
