using System;

namespace WeCode.API.Exceptions
{
    public class FilmeException : Exception
    {
        public FilmeException()
            :base("Este filme já está cadastrado.")
        {}
    }
}
