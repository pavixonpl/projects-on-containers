﻿using System;
using System.Threading.Tasks;
using Grpc.Core;
using Issues.API.Protos;

namespace Issues.API.GrpcServices
{
    public class GrpcStatusService : Protos.StatusService.StatusServiceBase
    {
        public override async Task<GetStatusesResponse> GetStatuses(GetStatusesRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<CreateStatusResponse> CreateStatus(CreateStatusRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<DeleteStatusResponse> DeleteStatus(DeleteStatusRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<RenameStatusResponse> RenameStatus(RenameStatusRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}