using System;

namespace PizzaHutAPI.Application.Common.Exceptions
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException() : base("User was not found!")
        {

        }
    }
}
