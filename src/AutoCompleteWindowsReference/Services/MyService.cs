using System;
using System.Threading.Tasks;
using AutoCompleteWindowsReference.Interfaces;

namespace AutoCompleteWindowsReference.Services
{
    public class MyService : IMyService
    {
        public async Task DoSomethingAsync()
        {
            Console.WriteLine("Starting to do something");

            await Task.Delay(1000);

            Console.WriteLine("Finished doing something");
        }
    }
}
