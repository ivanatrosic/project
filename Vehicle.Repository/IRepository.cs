using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Vehicle.Repository
{
    public interface IRepository<Tcontext>
    {
        //T GetById<T>(int id) where T : class;
        void Insert<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        //IEnumerable<T> GetAll<T>() where T : class;
    }
}
