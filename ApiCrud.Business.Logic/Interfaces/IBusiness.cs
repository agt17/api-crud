using ApiCrud.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Business.Logic.Interfaces
{
    public interface IBusiness<T>
    {
        T Create(T model);
        T ReadById(int id);
        List<T> ReadAll();
        T Update(int id, T model);
        int Delete(int id);
    }
}
