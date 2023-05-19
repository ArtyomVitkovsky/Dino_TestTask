using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public enum AnimationActionType
    {
        Idle,
        Action,
    }

    [Serializable]
    public class AnimationAction
    {
        public string trigger;
        public AnimationActionType type;
    }

    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationAction[] animationActions;
        [SerializeField] private AnimationAction[] animationActionScenario;

        public void SetActive(bool isActive)
        {
            animator.enabled = isActive;
        }
        
        public void PlayFullCycle(bool loop)
        {
            ResetTriggers();

            StartCoroutine(PlayFullCycleCoroutine(loop));
        }

        private void ResetTriggers()
        {
            foreach (var action in animationActions)
            {
                animator.ResetTrigger(action.trigger);
            }
        }

        public void SetTrigger(AnimationActionType type)
        {
            var action = animationActions.FirstOrDefault(a => a.type == type);

            if (action != null)
            {
                ResetTriggers();
                animator.SetTrigger(action.trigger);
            }
        }

        IEnumerator PlayFullCycleCoroutine(bool loop)
        {
            foreach (var action in animationActionScenario)
            {
                yield return StartCoroutine(PlayAnimationCoroutine(action.trigger));
            }

            if (loop)
            {
                PlayFullCycle(true);
            }
        }

        IEnumerator PlayAnimationCoroutine(string trigger)
        {
            animator.SetTrigger(trigger);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}