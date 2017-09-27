using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Paging
{
    public class PagingDetails : IPagingDetails 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageSkip { get; set; }
        public string Filter { get; set; }


        //public PagingDetails()
        //    : this(null, 1, 5)
        //{
        //}

        public PagingDetails(string Filter, int pageNumber, int pageSize)
        {
            if (pageNumber == 0 || PageSize == 0)
            {
                this.PageNumber = 1;
                this.PageSize = 5;

            }
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PageSkip = PageSize * (PageNumber - 1);
            this.Filter = Filter;
        }
 
    }
}
