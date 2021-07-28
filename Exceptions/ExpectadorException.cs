using System;

namespace WeCode.API.Exceptions
{
    public class ExpectadorException : Exception
    {
        public ExpectadorException()
            : base("Este expectador já está cadastrado.")
        {}
    }
}
