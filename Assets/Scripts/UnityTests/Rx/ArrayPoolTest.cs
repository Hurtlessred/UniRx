#if CSHARP_7_OR_LATER || (UNITY_2018_3_OR_NEWER && (NET_STANDARD_2_0 || NET_4_6))
using NUnit.Framework;
using System;
using exiii.Unity.Rx.Async.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exiii.Unity.Rx.Tests
{
    
    public class ArrayPoolTest
    {
        [Test]
        public void Rent()
        {
            var pool = exiii.Unity.Rx.Async.Internal.ArrayPool<int>.Shared;

            {
                var xs = pool.Rent(9);
                xs.Length.Is(16);
                pool.Return(xs);
                object.ReferenceEquals(pool.Rent(9), xs).IsTrue();
            }
            {
                //1048576
                var xs = pool.Rent(1048577);
                xs.Length.Is(2097152);
                pool.Return(xs);

                object.ReferenceEquals(pool.Rent(1048577), xs).IsFalse(); // no pooled
            }
        }
    }
}

#endif