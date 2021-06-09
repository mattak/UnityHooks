using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHooks.Input
{
    [RequireComponent(typeof(ToggleInput))]
    public class ToggleInput : MonoBehaviour
    {
        public IObservable<bool> isOnAsObservable => this.GetComponent<Toggle>()
            .OnValueChangedAsObservable()
            .DistinctUntilChanged()
            .Skip(1); // ignore first value
    }
}