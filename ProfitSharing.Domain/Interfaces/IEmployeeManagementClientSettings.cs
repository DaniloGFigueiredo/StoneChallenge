using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitSharing.Domain.Interfaces
{
    public interface IEmployeeManagementClientSettings
    {
        string URI { get; set; }
        string AccessKey { get; set; }
    }
}
