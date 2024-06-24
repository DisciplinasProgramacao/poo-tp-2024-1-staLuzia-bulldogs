using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class ValorNegativoException : Exception
    {
        public ValorNegativoException(string? message) : base(message)
        {
        }
    }
}
