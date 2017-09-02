using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;


namespace Vehicle.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public UnitOfWork(DbContext Context)
        {
            _context = Context;
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose ()
        {
            _context.Dispose();
        }


    }
}
