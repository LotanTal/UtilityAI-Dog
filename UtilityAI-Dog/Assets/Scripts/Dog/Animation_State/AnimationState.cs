using System;
using CorgiTools.DogControllers;
using UnityEngine;

namespace CorgiTools.AnimationStates
{
    [Serializable]
    public abstract class AnimationState
    {
        /// <summary>
        /// Set the animation
        /// </summary>
        public abstract void SetAnimation(AnimationController animationController);

        /// <summary>
        /// Reverse the effects of the animation that was set 
        /// </summary>
        public abstract void AnimationStateDefualt(AnimationController animationController);
    }
}
