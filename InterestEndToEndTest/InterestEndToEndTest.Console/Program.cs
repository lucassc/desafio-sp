using InterestEndToEndTest.Console.InterestCalc;
using System.Threading;

namespace InterestEndToEndTest.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Thread.Sleep(1000);

            var tests = new InterestCalcTest();

            System.Console.WriteLine("Start End-To-End Tests");

            tests.ExecuteInterestCalcTest();

            System.Console.WriteLine("Finish End-To-End Tests");
        }
    }
}