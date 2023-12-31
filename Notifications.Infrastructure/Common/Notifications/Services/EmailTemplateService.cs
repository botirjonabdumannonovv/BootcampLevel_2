﻿using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Infrastructure.Application.Common.Models.Querying;
using Notifications.Infrastructure.Application.Common.Notifications.Services;
using Notifications.Infrastructure.Application.Common.Querying.Extensions;
using Notifications.Infrastructure.Domain.Entities;
using Notifications.Infrastructure.Domain.Enums;
using Notifications.Infrastructure.Persistence.Repositories.Interfaces;

namespace Notifications.Infrastructure.Infrastrucutre.Common.Notifications.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IValidator<EmailTemplate> _emailTemplateValidator;

    public EmailTemplateService(
        IEmailTemplateRepository emailTemplateRepository,
        IValidator<EmailTemplate> emailTemplateValidator
    )
    {
        _emailTemplateRepository = emailTemplateRepository;
        _emailTemplateValidator = emailTemplateValidator;
    }

    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        _emailTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOptions)
            .ToListAsync(cancellationToken: cancellationToken);

    public async ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _emailTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = _emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return _emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}