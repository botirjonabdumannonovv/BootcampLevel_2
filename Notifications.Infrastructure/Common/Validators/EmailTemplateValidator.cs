using FluentValidation;
using Notifications.Infrastructure.Domain.Entities;
using Notifications.Infrastructure.Domain.Enums;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Validators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);

        RuleFor(template => template.Type)
            .Equal(NotificationType.Email);
    }
}