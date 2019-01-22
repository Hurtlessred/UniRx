using System;

namespace exiii.Unity.Rx.Operators
{
    internal class FrameIntervalObservable<T> : OperatorObservableBase<exiii.Unity.Rx.FrameInterval<T>>
    {
        readonly IObservable<T> source;

        public FrameIntervalObservable(IObservable<T> source)
            : base(source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
        }

        protected override IDisposable SubscribeCore(IObserver<exiii.Unity.Rx.FrameInterval<T>> observer, IDisposable cancel)
        {
            return source.Subscribe(new FrameInterval(observer, cancel));
        }

        class FrameInterval : OperatorObserverBase<T, exiii.Unity.Rx.FrameInterval<T>>
        {
            int lastFrame;

            public FrameInterval(IObserver<exiii.Unity.Rx.FrameInterval<T>> observer, IDisposable cancel)
                : base(observer, cancel)
            {
                this.lastFrame = UnityEngine.Time.frameCount;
            }

            public override void OnNext(T value)
            {
                var now = UnityEngine.Time.frameCount;
                var span = now - lastFrame;
                lastFrame = now;

                base.observer.OnNext(new exiii.Unity.Rx.FrameInterval<T>(value, span));
            }

            public override void OnError(Exception error)
            {
                try { observer.OnError(error); }
                finally { Dispose(); }
            }

            public override void OnCompleted()
            {
                try { observer.OnCompleted(); }
                finally { Dispose(); }
            }
        }
    }
}