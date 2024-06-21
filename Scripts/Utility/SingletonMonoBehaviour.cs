using System;
using UnityEngine;

namespace Cosmos.Utility
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected abstract bool IsDontDestroyOnLoad { get; }

        private static T instance;
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    Type t = typeof(T);
                    instance = (T)FindObjectOfType(t);
                    if (!instance)
                    {
                        Debug.LogError(t + "ÇÕë∂ç›ÇµÇ‹ÇπÇÒ");
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (this != Instance)
            {
                Destroy(this);
                return;
            }
            if (IsDontDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}

