﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
