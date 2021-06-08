using System;
using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooks.Input;

namespace Examples.MemoryPuzzle.Scripts
{
    [RequireComponent(typeof(ButtonInput))]
    public class ResetButtonBinder : MonoBehaviour
    {
        private void Start()
        {
            var reset = Hooks.UseState(HookKeys.Reset);
            GetComponent<ButtonInput>().clickAsObservable
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(_ => reset.Update(true))
                .AddTo(this);
        }
    }
}