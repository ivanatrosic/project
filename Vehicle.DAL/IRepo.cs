using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Service
{
    public interface IRepo : IDisposable
    {
        T Insert<T>(T item, bool saveNow)
            where T : class;

        T Update<T>(T item, bool saveNow)
            where T : class;

        T Delete<T>(T item, bool saveNow)
            where T : class;


    }
}
