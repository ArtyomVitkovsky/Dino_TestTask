using System;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.ObjectsPool
{
    [Serializable]
    public class PoolObject<T>
    {
        public T instance;
        public bool isActive;

        public PoolObject(T instance)
        {
            this.instance = instance;
        }
        
        public PoolObject(T instance, GameObject gameObject)
        {
            this.instance = instance;
        }
    }
}