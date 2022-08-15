
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PreparingBreakFast
{
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    internal class BreakFastDemo
    {
        private static Juice PourOJ()
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  Pouring Mango juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
         Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Putting a slice of bread in the toaster :");
            }
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  Preparing....");
            Task.Delay(4000).Wait();
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Remove toast from toaster");

            return new Toast();
        }

        private static Task<Toast> ToastBreadAsync(int slices)
        {
            return Task.Run<Toast>(() => { return ToastBread(slices); });
        }

        private static Task<Bacon> FryBaconAsync(int slices)
        {
            return Task.Run<Bacon>(async () => {
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} putting {slices} slices of bacon in the pan");
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  preparing first side of bacon");
                await Task.Delay(4000);
                for (int slice = 0; slice < slices; slice++)
                {
                    Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  flipping a slice of bacon");
                }
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} preparing second side of bacon");
                await Task.Delay(4000);
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Put bacon on plate");
                return new Bacon();
            });
        }

        private static Task<Egg> FryEggsAsync(int howMany)
        {
            return Task.Run<Egg>(async () => {
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Warming the egg pan");
                await Task.Delay(4000);
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  cracking {howMany} eggs");
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} cooking the eggs");
                await Task.Delay(4000);
                Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}  Putting eggs on the plate");
                return new Egg();
            });
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Pouring coffee");
            return new Coffee();
        }

        public static async Task PrepareBreakfast()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee ready");


            await Task.WhenAll(FryEggsAsync(2), FryBaconAsync(2));

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice j = PourOJ();
            Console.WriteLine("juice is ready");
            Console.WriteLine("Breakfast is ready!");
        }
    }

    class Program
    {
        async static Task Main(string[] args)
        {
            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
            await BreakFastDemo.PrepareBreakfast();
            _watch.Stop();
            Console.WriteLine($"Total time taken to prepare breakfast {_watch.Elapsed.TotalSeconds}");
        }
    }
}