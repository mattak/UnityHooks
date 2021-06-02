using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHooks.Input
{
    [RequireComponent(typeof(Button))]
    public class ButtonInput : MonoBehaviour
    {
        public IObservable<Unit> clickAsObservable => this.GetComponent<Button>().OnClickAsObservable();
    }
}