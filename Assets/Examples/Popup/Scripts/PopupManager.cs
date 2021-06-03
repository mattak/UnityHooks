using System.Collections.Generic;
using UnityEngine;

namespace Examples.Popup.Scripts
{
    public class PopupManager : SingletonMonoBehaviour<PopupManager>
    {
        [SerializeField] private Transform _root = default;
        private Stack<Component> _stack = new Stack<Component>();

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this.gameObject);
            this._root.gameObject.SetActive(false);
        }

        public TComponent Show<TComponent>(TComponent prefab) where TComponent : Component
        {
            var component = Instantiate(prefab, _root.transform, false);
            _stack.Push(component);
            this._root.gameObject.SetActive(true);
            return component;
        }

        public void Dismiss()
        {
            var component = _stack.Pop();
            Destroy(component.gameObject);

            if (_stack.Count < 1) this._root.gameObject.SetActive(false);
        }
    }
}