using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Common.Logic.Log4Net
{
    public interface ILogger
    {
        void Debug(Object message);
        void Error(Object message);
    }
}
