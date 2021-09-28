using ToDoList.Models;

namespace ToDoList.Web.Models
{
    public sealed class FailureModel
    {
        public string Message { get; set; }

        public static FailureModel CreateFor(DomainException domainException)
        {
            return new FailureModel
            {
                Message = domainException.Message
            };
        }

        public static FailureModel CreateFor(string message)
        {
            return new FailureModel
            {
                Message = message
            };
        }
    }
}