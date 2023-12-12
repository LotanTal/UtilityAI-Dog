using System.Collections;
using System.Collections.Generic;
using CorgiTools.DogControllers;
using UnityEngine;
namespace CorgiTools.AnimationStates
{
    public class As_Sleep : AnimationState
    {
        public override void AnimationStateDefualt(AnimationController animationController)
        {
            animationController.SetBoolAnimation("Sleep_b", false);
        }

        public override void SetAnimation(AnimationController animationController)
        {
            animationController.SetBoolAnimation("Sleep_b", true);

        }


    }
}
