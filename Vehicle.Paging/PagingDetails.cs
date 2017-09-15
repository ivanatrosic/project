using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Paging
{
    public class PagingDetails
    {
        public int PageNumber;
        public int PageSize;
        public int PageSkip;
        public PagingDetails()
            : this(1, 5)
        {
        }

        public PagingDetails(int pageNumber, int pageSize)
        {
            if (pageNumber == 0 || PageSize == 0)
            {
                this.PageNumber = 1;
                this.PageSize = 5;

            }
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PageSkip = PageSize * (PageNumber - 1);
        }
 
    }
}
