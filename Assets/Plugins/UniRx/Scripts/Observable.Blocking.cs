using System;

namespace exiii.Unity.Rx
{
    public static partial class Observable
    {
        public static T Wait<T>(this IObservable<T> source)
        {
            return new exiii.Unity.Rx.Operators.Wait<T>(source, InfiniteTimeSpan).Run();
        }

        public static T Wait<T>(this IObservable<T> source, TimeSpan timeout)
        {
            return new exiii.Unity.Rx.Operators.Wait<T>(source, timeout).Run();
        }
    }
}
