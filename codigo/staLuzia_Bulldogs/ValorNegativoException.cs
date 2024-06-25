using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staLuzia_Bulldogs
{
    internal class ValorInvalidoException : Exception
    {
        public ValorInvalidoException(string? message) : base(message)
        {
        }
    }
}
