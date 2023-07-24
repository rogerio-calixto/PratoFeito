﻿namespace _Architecture.Infrastructure.Interceptors;

public sealed class EventsInterceptor<TMapper> : SaveChangesInterceptor
    where TMapper : IIntegrationEventMapper
{
    private readonly IMediator _mediator;
    private readonly TMapper _mapper;

    public EventsInterceptor(IMediator mediator, TMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if (context is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var aggregateRoots = context.ChangeTracker
                                    .Entries<AggregateRoot>()
                                    .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                                    .Select(e => e.Entity)
                                    .ToList();

        var domainEvents = aggregateRoots
                           .SelectMany(x => x.DomainEvents!)
                           .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }

        aggregateRoots.ForEach(domainEntity => domainEntity.ClearDomainEvents());

        var integrationEventLogs = _mapper.Map(domainEvents);

        await context.Set<IntegrationEventLog>().AddRangeAsync(integrationEventLogs, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
