﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitSharing.Domain.Interfaces
{
    public interface IProfitSharingService
    {
        Task CalculateProfiSharing();
    }
}