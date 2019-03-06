using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Repository.Logic.Interfaces
{
    public interface ICreate<T>
    {
        T Create(T model);
    }
}
