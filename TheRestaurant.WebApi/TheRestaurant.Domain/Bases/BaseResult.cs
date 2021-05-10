using System.Collections.Generic;
using System.Linq;

namespace TheRestaurant.Domain.Bases
{
    public class BaseResult
    {
        public bool Valid { get => !Messages.Any(); }

        public List<string> Messages { get; set; }

        public BaseResult() => Messages = new List<string>();

        public BaseResult(string message) => Messages = new List<string>() { message };

        public BaseResult(List<string> messages) => Messages = messages;
    }

    public class BaseResult<T> : BaseResult
    {
        public BaseResult() : base() { }
        public BaseResult(string message) : base(message) { }
        public BaseResult(List<string> messages) : base(messages) { }
        public T Data { get; set; }
    }
}
