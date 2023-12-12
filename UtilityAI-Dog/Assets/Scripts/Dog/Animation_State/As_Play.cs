using System.Collections;
using System.Collections.Generic;
using CorgiTools.DogControllers;
using UnityEngine;
namespace CorgiTools.AnimationStates
{
    public class As_Play : AnimationState
    {
        public override void AnimationStateDefualt(AnimationController animationController)
        {
            animationController.SetValueAnimation("ActionType_int", 0);
        }

        public override void SetAnimation(AnimationController animationController)
        {
            animationController.SetValueAnimation("ActionType_int", 13);
        }


    }
}
