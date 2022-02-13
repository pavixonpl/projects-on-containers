﻿using EventBus.Events;

namespace Issues.Application.IntegrationEvents.Events;

public class OrganizationCreatedIntegrationEvent : IntegrationEvent
{
    public OrganizationCreatedIntegrationEvent(string organizationId)
    {
        OrganizationId = organizationId;
    }

    public string OrganizationId { get; }
}