using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Common.Logic.Log4Net
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog log;

        public Log4NetAdapter()
        {
            this.log = LogManager.
                GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Error(object message)
        {
            this.log.Error(message);
        }
    }
}
