using UnityEngine;

namespace Examples.Popup.Scripts
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T) FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        Debug.LogError($"Not found singleton instance of {typeof(T)}");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (this != Instance)
            {
                Destroy(this);
                Debug.LogError(
                    $"{typeof(T)} is already attached on the other game object. please check game object of {Instance.gameObject.name}");
            }
        }
    }
}