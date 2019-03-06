using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Business.Logic
{
    public static class Calculations
    {
        public static int CalculateYears(DateTime dob)
        {
            return ((DateTime.Now.Year - dob.Year) * 372 +
                (DateTime.Now.Month - dob.Month) * 31 +
                (DateTime.Now.Day - dob.Day)) / 372;
        }
    }
}
