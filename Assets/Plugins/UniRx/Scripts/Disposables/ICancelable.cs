using System;
using System.Collections.Generic;
using System.Text;

namespace exiii.Unity.Rx
{
    public interface ICancelable : IDisposable
    {
        bool IsDisposed { get; }
    }
}
