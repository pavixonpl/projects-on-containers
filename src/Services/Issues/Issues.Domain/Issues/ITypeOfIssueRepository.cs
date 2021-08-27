﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Issues.Domain.TypesOfIssues;

namespace Issues.Domain.Issues
{
    public interface ITypeOfIssueRepository
    {
        Task<TypeOfIssue> GetTypeOfIssueByIdAsync(string id);
        Task<IEnumerable<TypeOfIssue>> GetTypeOfIssuesForOrganizationAsync(string organizationId);
        Task<TypeOfIssue> AddNewTypeOfIssueAsync(string organizationId, string name);
    }
}