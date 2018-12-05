using System;
using System.Diagnostics;

namespace ConsoleTestStaticPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(5);
        }

        static void Test(int count)
        {
            for (int i = 0; i < count; i++) { Test(); }
        }

        static void Test()
        {
            TestInstance testInstance = new TestInstance();
            TestStatic testStatic = new TestStatic();

            Stopwatch swInstance = Stopwatch.StartNew();
            testInstance.Test(2000000);
            swInstance.Stop();

            Stopwatch swStatic = Stopwatch.StartNew();
            testStatic.Test(2000000);
            swStatic.Stop();

            Console.WriteLine($"Static test took {swStatic.ElapsedMilliseconds} milliseconds.");
            Console.WriteLine($"Instance test took {swInstance.ElapsedMilliseconds} milliseconds.");
        }
    }

    class TestInstance
    {

        public void Test(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string test;
                test = "456";
            }
        }

    }

    class TestStatic
    {

        string test = "123";

        public void Test(int count)
        {
            for (int i = 0; i < count; i++)
            {
                test = "456";
            }
        }

    }

}
