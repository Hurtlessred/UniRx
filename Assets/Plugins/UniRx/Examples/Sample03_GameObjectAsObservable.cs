#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_METRO)

using UnityEngine;
using exiii.Unity.Rx.Triggers; // for enable gameObject.EventAsObservbale()
using exiii.Unity.Rx.Subscribe;

namespace exiii.Unity.Rx.Examples
{
    public class Sample03_GameObjectAsObservable : MonoBehaviour
    {
        void Start()
        {
            // All events can subscribe by ***AsObservable if enables exiii.Unity.Rx.Triggers
            this.OnMouseDownAsObservable()
                .SelectMany(_ => this.gameObject.UpdateAsObservable())
                .TakeUntil(this.gameObject.OnMouseUpAsObservable())
                .Select(_ => Input.mousePosition)
                .RepeatUntilDestroy(this)
                .Subscribe(x => Debug.Log(x), ()=> Debug.Log("!!!" + "complete"));
        }
    }
}

#endif