using System;
using UnityEngine;

namespace Modules.Game.Scripts
{
    public class CameraFollower : Follower
    {
        [SerializeField] protected Transform cameraTransform;

        private void Start()
        {
            cameraTransform.localPosition = offset;
        }

        protected void Update()
        {
            Follow(Time.fixedDeltaTime);
        }
    }
}
