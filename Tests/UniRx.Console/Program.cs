#pragma warning disable CS0162

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using exiii.Unity.Rx.Async;

namespace exiii.Unity.Rx
{
    class Program
    {
        static void Main(string[] args)
        {
            // my path:)
            //var path = @"C:\Users\neuecc\Documents\Git\neuecc\exiii.Unity.Rx\Assets\Plugins\exiii.Unity.Rx\Scripts\UnityEngineBridge\Triggers";
            //var outpath = @"";
            //TriggerFileGenerator.GenerateAsyncTrigger(path, outpath);

            //            Console.WriteLine("-- -");
            //          Console.WriteLine(code);
            //        Console.WriteLine("---");

            Run().Forget();
            Console.ReadLine();
        }

        static async UniTask Run()
        {
            var cts = new CancellationTokenSource();
            var rp = new ReactiveProperty<int>();
            var _ = Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(x => rp.Value = 9999);
            var v = await rp.WaitUntilValueChangedAsync(cts.Token);
            Console.WriteLine(v);
        }
    }
}

#pragma warning restore CS0162