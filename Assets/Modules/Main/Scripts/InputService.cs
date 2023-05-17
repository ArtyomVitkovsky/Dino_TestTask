using UnityEngine;
using UnityEngine.Events;

namespace Modules.Main.Scripts
{
    public class InputService : MonoBehaviour
    {
        public UnityAction<float> OnXAxisMove;
        public UnityAction<float> OnZAxisMove;
        public UnityAction<float> OnYAxisMove;
    }
}