using System;
using System.Threading.Tasks;
using Glue.Example.Common;

namespace Glue.Example.Server
{
    public sealed class SampleService
    {
        public void SampleMethod()
        {
            Console.WriteLine($"Called {nameof(SampleMethod)}!");
        }

        public Task SampleMethodAsync()
        {
            Console.WriteLine($"Called {nameof(SampleMethodAsync)}!");

            return Task.CompletedTask;
        }

        public SampleResultData SampleMethodWithResult()
        {
            Console.WriteLine($"Called {nameof(SampleMethodWithResult)}!");

            return new SampleResultData
            {
                Date = DateTime.UtcNow,
                Number = 42,
                Token =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                    "labore et dolore magna aliqua."
            };
        }

        public Task<SampleResultData> SampleMethodWithResultAsync()
        {
            Console.WriteLine($"Called {nameof(SampleMethodWithResultAsync)}!");

            return Task.FromResult(new SampleResultData
            {
                Date = DateTime.UtcNow,
                Number = 42,
                Token = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                        "ut labore et dolore magna aliqua."
            });
        }

        public Task<long> SumAsync(long a, long b)
        {
            Console.WriteLine($"Called {nameof(SumAsync)} with {nameof(a)} = {a}, {nameof(b)} = {b}!");

            return Task.FromResult(a + b);
        }

        public Task<string> ThrowExceptionAsync(string text)
        {
            Console.WriteLine($"Called {nameof(ThrowExceptionAsync)} with {nameof(text)} = {text}!");

            throw new Exception($"Text of exception: {text}");

            return Task.FromResult("Exception not thrown.");
        }
    }
}