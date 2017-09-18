using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Paging
{
    public interface IPagingDetails
    {
         int PageNumber { get; set; }
         int PageSize { get; set; }
         int PageSkip { get; set; }
         string Filter { get; set; }

    }
}
