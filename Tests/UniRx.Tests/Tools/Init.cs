using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exiii.Unity.Rx.Tests
{
    [TestClass]
    public class Init
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext ctx)
        {
            Scheduler.DefaultSchedulers.SetDotNetCompatible();
        }
    }
}