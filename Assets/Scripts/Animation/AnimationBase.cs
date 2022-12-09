using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public enum AnimationType
    {
        ATTACK,
        DEATH,
        IDLE,
        NONE,
        RUN
    }

    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSetup> animationSetups;

        public void PlayAnimationType(AnimationType animationType)
        {
            var setup = animationSetups.Find(i => i.animationType == animationType);

            if(setup!= null && animator != null)
            {
                animator.SetTrigger(setup.trigger);
            }
        }
    }

    [System.Serializable]
    public class AnimationSetup
    {
        public AnimationType animationType;
        public string trigger;
    }
}
