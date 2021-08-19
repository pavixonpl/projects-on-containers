﻿using Architecture.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] //For moq purpose 

namespace Issues.Domain.GroupsOfIssues
{

    public class TypeOfGroupOfIssues : EntityBase
    {
        internal TypeOfGroupOfIssues(string organizationId, string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            OrganizationId = organizationId;
        }

        internal TypeOfGroupOfIssues()
        {

        }

        public virtual string Name { get; protected set; }
        public virtual string OrganizationId { get; protected set; }
        public virtual bool IsArchived { get; protected set; }

        public void RenameGroup(string newName)=> ChangeStringProperty("Name", newName);

        public void Archive(ITypeGroupOfIssuesArchivePolicy policy)
        {
            IsArchived = true;
            policy.Archive();
        }

        public void UnArchive()
        {
            IsArchived = false;
        }
    }
}
