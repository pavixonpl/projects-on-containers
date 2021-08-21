﻿using Architecture.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issues.Domain.StatusesFlow
{
    public class StatusInFlow : EntityBase
    {
        public StatusInFlow(Status parentStatus, StatusFlow statusFlow, int indexInFlow)
        {
            Id = Guid.NewGuid().ToString();
            ParentStatus = parentStatus;
            StatusFlow = statusFlow;
            IndexInFlow = indexInFlow;
            ConnectedStatuses = new List<StatusInFlowConnection>();
            IsArchived = false;
        }
        public StatusInFlow()
        {
            ConnectedStatuses = new List<StatusInFlowConnection>();
        }
        public virtual Status ParentStatus { get; set; }
        public virtual string ParentStatusId { get; set; }
        //one to many
        public virtual StatusFlow StatusFlow { get; set; }
        public virtual int IndexInFlow { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual List<StatusInFlowConnection> ConnectedStatuses { get; set; } //dunno how i will do this xD, functional tests will show

        public void AddConnectedStatus(Status status)
        {
            if (status == null)
                throw new InvalidOperationException("Given status to add is null");

            if (ConnectedStatuses.Any(s=> s.ConnectedWithParent.Id == status.Id))
                throw new InvalidOperationException(
                    $"Status with id: {status.Id} is already added to connected statuses where status in flow has id: {Id}");

            var connectedStatus = new StatusInFlowConnection(status, this);
            ConnectedStatuses.Add(connectedStatus);
        }

        public void DeleteConnectedStatus(string id)
        {

            var connectionToDelete = ConnectedStatuses.FirstOrDefault(s => s.Id == id);
            if (connectionToDelete == null)
                throw new InvalidOperationException($"Requested status in flow to delete with id: {id} in parent {Id} doesn't exist");

            ConnectedStatuses.Remove(connectionToDelete);
        }

        public void Archive()
        {
            IsArchived = true;
        }

        public void UnArchive()
        {
            IsArchived = false;
        }
    }
}
