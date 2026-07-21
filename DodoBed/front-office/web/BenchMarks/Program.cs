using BenchMarks.Application;
using BenchmarkDotNet.Running;

namespace BenchMarks
{
    //Need to run benchmark in Release
    class Program
    {
        static void Main(string[] args)
        {
            var benchGuest = BenchmarkRunner.Run<GuestQuery>();
        }
    }
}
