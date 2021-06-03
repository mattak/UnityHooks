using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace UnityHooks.Input
{
    [RequireComponent(typeof(InputField))]
    public class InputFieldInput : MonoBehaviour
    {
        private readonly Subject<string> _subject = new Subject<string>();

        public IObservable<string> textAsObservable => _subject;

        private void Start()
        {
            var inputField = GetComponent<InputField>();
            this.UpdateAsObservable()
                .Select(_ => inputField.text)
                .DistinctUntilChanged()
                .Subscribe(_subject)
                .AddTo(this);
        }
    }
}