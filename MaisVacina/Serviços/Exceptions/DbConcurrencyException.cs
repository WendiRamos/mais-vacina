using System;

namespace MaisVacina.Serviços.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message ) : base(message)
        {

        }
    }
}
