using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_csharp.Service
{
    interface IBaseService<T, U>
    {
        U Execute(T input);
    }
}
