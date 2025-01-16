using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.Word.AdditionalCode
{
    public static class DoubleZero
    {
        public static string Doublezero(double num)
        {
            return $"{num:N2}".Replace('.', ',');
        }
    }
}
