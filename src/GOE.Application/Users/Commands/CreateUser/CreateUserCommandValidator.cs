using FluentValidation;

namespace GOE.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Username)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(9);
            RuleFor(c => c.Lastname)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(9);
            RuleFor(c => c.Firstname)
                .NotEmpty()
                .MaximumLength(60)
                .MinimumLength(9);
            RuleFor(c => c.Password)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(30);
            RuleFor(c => c.Email)
                .EmailAddress();
            RuleFor(c => c.PhoneNumber)
                .Matches("[0-9]{10}");
            RuleFor(c => c.Birthday)
                .LessThan(DateTime.UtcNow.AddYears(-14));
        }
    }
}
