using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCApplication.Services
{
    public interface IRepo<T>
    {
        void Add(T t);
        void Update(int id, T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
