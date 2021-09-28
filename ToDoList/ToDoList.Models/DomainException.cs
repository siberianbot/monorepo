using System;

namespace ToDoList.Models
{
    public sealed class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            //
        }
    }
}