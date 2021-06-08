using System;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace UnityHooks.Input
{
    public class PointerDownInput : UIBehaviour
    {
        public IObservable<PointerEventData> pointerDownAsObservable => this.OnPointerClickAsObservable();
    }
}