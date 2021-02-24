using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.DAO
{
    public interface IBaseDao<T>
    {
        List<T> ListAll();
        T Create(T value);
        T Edit(T value);
        T Delete(T value);
        T FindOne(string identifier);
    }
}
