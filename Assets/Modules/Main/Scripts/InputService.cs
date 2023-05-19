using Modules.HitMasterGame.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.Main.Scripts
{
    public class InputService : MonoBehaviour
    {
        private bool isPressed;

        private Vector3 pressPosition;
        
        public UnityAction<Vector3> OnTouch;
        public UnityAction<Vector3> OnTouchRelease;

        private void Update()
        {
            if(GameSettings.IS_PAUSED) return;

#if !UNITY_EDITOR
            switch (Input.touchCount)
            {
                case 0:
                {
                    if(isPressed) OnTouchRelease?.Invoke(pressPosition);
                    isPressed = false;
                    break;
                }
                case 1:
                {
                    pressPosition = Input.GetTouch(0).position;
                    isPressed = true;
                    OnTouch?.Invoke(pressPosition);
                    break;
                }
            }
#endif

#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                pressPosition = Input.mousePosition;
                OnTouch?.Invoke(pressPosition);
                isPressed = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                pressPosition = Input.mousePosition;
                if(isPressed) OnTouchRelease?.Invoke(pressPosition);
                isPressed = false;
            }
#endif
            
        }
    }
}