using System;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Unit
{
    [Serializable]
    public class StatParameter<T>
    {
        [SerializeField] private T value;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChanged?.Invoke(this.value);
            }
        }

        public Action<T> OnChanged;
    }
}