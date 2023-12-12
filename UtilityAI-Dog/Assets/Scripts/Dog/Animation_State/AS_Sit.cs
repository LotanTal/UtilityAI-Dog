using System.Collections;
using System.Collections.Generic;
using CorgiTools.DogControllers;
using UnityEngine;
namespace CorgiTools.AnimationStates
{
    public class AS_Sit : AnimationState
    {
        public override void AnimationStateDefualt(AnimationController animationController)
        {
            animationController.SetBoolAnimation("Sit_b", false);
        }

        public override void SetAnimation(AnimationController animationController)
        {
            animationController.SetBoolAnimation("Sit_b", true);
        }
    }
}
