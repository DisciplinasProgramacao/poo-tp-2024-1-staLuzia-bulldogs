using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClienteJaPossuiMesa : [System.Serializable]
public class ClienteJaPossuiMesaException : System.RuntimeException
{
    //Apenas um teste realizado por Sanzio™
    public ClienteJaPossuiMesaException() { }
    public ClienteJaPossuiMesaException(string message) : base(message) { }
    public ClienteJaPossuiMesaException(string message, System.Exception inner) : base(message, inner) { }
    protected ClienteJaPossuiMesaException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}