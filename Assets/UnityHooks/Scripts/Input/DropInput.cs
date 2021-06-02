using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityHooks.Input
{
    public class DropInput : MonoBehaviour, IDropHandler
    {
        private readonly ISubject<PointerEventData> _dropSubject = new Subject<PointerEventData>();
        public IObservable<PointerEventData> dropAsObservable => _dropSubject;

        public void OnDrop(PointerEventData eventData)
        {
            _dropSubject.OnNext(eventData);
        }
    }
}