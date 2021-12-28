﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Issues.Domain.GroupsOfIssues;

namespace Issues.Infrastructure.Services.Files.CsvMaps
{
    public class GroupsOfIssuesMap : ClassMap<GroupOfIssues>
    {
        public GroupsOfIssuesMap()
        {
            AutoMap(System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
