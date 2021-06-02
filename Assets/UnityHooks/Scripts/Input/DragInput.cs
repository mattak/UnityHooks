using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityHooks.Input
{
    public class DragInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private readonly ISubject<PointerEventData> _dragSubject = new Subject<PointerEventData>();
        private readonly ISubject<PointerEventData> _beginDragSubject = new Subject<PointerEventData>();
        private readonly ISubject<PointerEventData> _endDragSubject = new Subject<PointerEventData>();

        public IObservable<PointerEventData> dragAsObservable => _dragSubject;
        public IObservable<PointerEventData> beginDragAsObservable => _beginDragSubject;
        public IObservable<PointerEventData> endDragAsObservable => _endDragSubject;

        public void OnDrag(PointerEventData eventData)
        {
            _dragSubject.OnNext(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _beginDragSubject.OnNext(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _endDragSubject.OnNext(eventData);
        }
    }
}