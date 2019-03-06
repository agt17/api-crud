using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Repository.Logic.Interfaces
{
    public interface IRepository<T> : ICreate<T> , IRead<T>, IReadAll<T>, IUpdate<T>, IDelete<T>
    {
    }
}
