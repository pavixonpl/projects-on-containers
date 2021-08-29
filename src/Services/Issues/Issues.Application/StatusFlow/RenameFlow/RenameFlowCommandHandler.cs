﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Architecture.DDD.Repositories;
using Issues.Domain.StatusesFlow;
using MediatR;

namespace Issues.Application.StatusFlow.RenameFlow
{
    public class RenameFlowCommandHandler : IRequestHandler<RenameFlowCommand>
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RenameFlowCommandHandler(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(RenameFlowCommand request, CancellationToken cancellationToken)
        {
            var flow = await _statusRepository.GetFlowById(request.FlowId);
            ValidateFlowWithRequestedParameters(flow, request);

            flow.Rename(request.NewName);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }

        private void ValidateFlowWithRequestedParameters(Domain.StatusesFlow.StatusFlow status, RenameFlowCommand request)
        {
            if (status is null)
                throw new InvalidOperationException($"Status flow with id: {request.FlowId} was not found");

            if (status.OrganizationId != request.OrganizationId)
                throw new InvalidOperationException($"Status flow with id: {request.FlowId} was found and is not accessible for organization with id: {request.OrganizationId}");

            if (status.IsArchived)
                throw new InvalidOperationException($"Status flow with id: {request.FlowId} is already archived");
        }
    }
}