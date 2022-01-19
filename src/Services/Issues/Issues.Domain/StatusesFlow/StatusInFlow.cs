﻿using Architecture.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Issues.Domain.StatusesFlow.DomainEvents;

namespace Issues.Domain.StatusesFlow
{
    public class StatusInFlow : EntityBase
    {
        public StatusInFlow(StatusFlow statusFlow, string name, bool isDefault) : this()
        {
            Id = Guid.NewGuid().ToString();
            StatusFlow = statusFlow;
            Name = name;
        }
        public StatusInFlow()
        {
            ConnectedStatuses = new List<StatusInFlowConnection>();
        }
        public StatusFlow StatusFlow { get; set; }
        public string StatusFlowId { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public List<StatusInFlowConnection> ConnectedStatuses { get; private set; } //dunno how i will do this xD, functional tests will show

        public void AddConnectedStatus(StatusInFlow status, StatusInFlowDirection direction)
        {
            if (status == null)
                throw new InvalidOperationException("Given status to add is null");

            if (ConnectedStatuses.Any(s=> s.ConnectedStatus.Id == status.Id && s.Direction == direction))
                throw new InvalidOperationException(
                    $"Status with connectedStatusId: {status.Id} is already added to connected statuses where status in flow has connectedStatusId: {Id} with direction of connection: {direction.ToString()}");

            var connectedStatus = new StatusInFlowConnection(this, direction, status);
            ConnectedStatuses.Add(connectedStatus);
            AddDomainEvent(new ConnectedStatusAddedDomainEvent(connectedStatus));
        }

        public void DeleteConnectedStatus(string connectedStatusId, params StatusInFlowDirection[] directions)
        {
            foreach (var connectionToDelete in directions.Select(direction => ConnectedStatuses.FirstOrDefault(s => s.ConnectedStatus.Id == connectedStatusId && s.Direction == direction)))
            {
                if (connectionToDelete == null)
                    throw new InvalidOperationException($"Requested status in flow to delete with connectedStatusId: {connectedStatusId} in parent {Id} doesn't exist");

                ConnectedStatuses.Remove(connectionToDelete);
                AddDomainEvent(new ConnectedStatusRemovedDomainEvent(connectionToDelete));
            }
        }

        public void SetDefaultToTrue()
        {
            IsDefault = true;
            AddDomainEvent(new StatusInFlowDefaultPropertyChangedToTrueDomainEvent(this));
        }

        public void SetDefaultToFalse()
        {
            IsDefault = false;
            AddDomainEvent(new StatusInFlowDefaultPropertyChangedToFalseDomainEvent(this));
        }
    }
}
