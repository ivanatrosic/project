using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicle.Common
{
    public class Paging : IPaging
    {
        #region Properties
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageSkip { get; set; }
        #endregion Properties

        #region Variables

        public int DefaultPageSize = 5;


        #endregion Variables

        #region Methods
        public Paging( int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber == 0 || PageSize == 0)
                {
                    this.PageNumber = 1;
                    this.PageSize = DefaultPageSize;

                }
                this.PageNumber = pageNumber;
                this.PageSize = pageSize;
                this.PageSkip = PageSize * (PageNumber - 1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }
        #endregion Methods
    }
}
