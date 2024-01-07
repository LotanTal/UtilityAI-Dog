using System;
using CorgiTools.AnimationStates;
using CorgiTools.Dog.Stats;
using CorgiTools.DogControllers;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

namespace CorgiTools.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "PlayWithBall", menuName = "UtilityAI/Actions/Play With Ball")]
    public class PlayWithBall : AIAction
    {
        private bool pickedUpBall;
        private AnimationStates.AnimationState _animationState = new AS_Sit();
        public override AnimationStates.AnimationState animationState
        {
            get { return _animationState; }
            protected set { _animationState = value; }
        }

        public override void ExecuteAction(DogController npc)
        {
            base.ExecuteAction(npc);
        }
        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, -5);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, 1);
        }

        public override void SetAnimation(DogController npc)
        {
            npc.animationController.currentAnimationState = animationState;
            npc.animationController.SetIKNeckRigWeight(0, 1f);

            float distanceToPlayer = Vector3.Distance(npc.context.player.transform.position, npc.transform.position);
            float distanceToBall = Vector3.Distance(npc.context.ball.transform.position, npc.transform.position);


            // if (distanceToPlayer < 5f && !pickedUpBall)
            // {
            //     npc.animationController.currentAnimationState.SetAnimation(npc.animationController);
            // }
            npc.mover.agent.stoppingDistance = 1f;

            if (pickedUpBall)
            {
                npc.animationController.currentAnimationState.AnimationStateDefualt(npc.animationController);
                DropBall(npc, npc.context.ball.GetComponent<Rigidbody>(), distanceToPlayer);

            }
            else
            {
                // DropBall(npc, npc.context.ball.GetComponent<Rigidbody>(), distanceToPlayer);
                npc.animationController.currentAnimationState.SetAnimation(npc.animationController);


            }


            if (distanceToBall < 1f && !pickedUpBall)
            {

                npc.animationController.Animator.Play("ToReady");
            }
            // if (distanceToPlayer < 5f && pickedUpBall)
            // {

            // }
        }

        private void DropBall(DogController npc, Rigidbody ballRB, float distanceToPlayer)
        {
            npc.mover.agent.stoppingDistance = 2f;

            if (distanceToPlayer < 5f)
            {
                pickedUpBall = false;
                ballRB.isKinematic = false;
                ballRB.AddForce(npc.context.dogMouthTransform.forward * 4f, ForceMode.Impulse);
                npc.context.ball.transform.parent = null;

                Debug.Log(pickedUpBall);
            }
        }

        public void FetchBall(DogController npc, Rigidbody ballRB) // called in ToPlayReady : StateMachineBehaviour
        {
            pickedUpBall = true;
            ballRB.isKinematic = true;
            npc.context.ball.transform.SetPositionAndRotation(npc.context.dogMouthTransform.position, npc.context.dogMouthTransform.rotation);
            npc.context.ball.transform.parent = npc.context.dogMouthTransform;
            // npc.mover.agent.stoppingDistance = 2f;

            Debug.Log(pickedUpBall);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            if (!pickedUpBall)
            {
                RequiredDestination = npc.context.ball.transform;
                npc.mover.destination = RequiredDestination;
            }
            else
            {
                RequiredDestination = npc.context.player.transform;
                npc.mover.destination = RequiredDestination;
            }

        }

    }
}






// using CorgiTools.Dog.Stats;
// using CorgiTools.DogControllers;
// using Unity.Mathematics;
// using UnityEngine;
// using UnityEngine.Animations;
// using UnityEngine.Animations.Rigging;

// namespace CorgiTools.UtilityAI.Actions
// {
//     [CreateAssetMenu(fileName = "PlayWithBall", menuName = "UtilityAI/Actions/Play With Ball")]
//     public class PlayWithBall : AIAction
//     {

//         // public override void ExecuteAction(DogController npc)
//         // {
//         //     // SetAnimation(npc);

//         //     // if (!hasExecuted)
//         //     // {
//         //     //     AffectStats(npc);
//         //     //     hasExecuted = true;
//         //     // }
//         // }
//         public override void AffectStats(DogController npc)
//         {
//             npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, -2);
//             npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, 1);
//         }


//         public override void SetAnimation(DogController npc)
//         {
//             float distanceToPlayer = Vector3.Distance(npc.context.player.transform.position, npc.transform.position);
//             Debug.Log("distanceToPlayer: " + distanceToPlayer);


//             if (distanceToPlayer < 3f)
//             {
//                 npc.animationController.SetBoolAnimation("Sit_b", true);

//                 // SetRequiredDestination to the player, since the ball is close enough
//                 // SetRequiredDestinationToPlayer(npc);
//             }
//             else
//             {
//                 npc.animationController.SetBoolAnimation("Sit_b", false);

//                 // Fetch the ball, set the required destination to the ball
//                 // SetRequiredDestinationToBall(npc);
//                 // npc.mover.MoveTo(RequiredDestination.position, npc);
//             }
//             npc.animationController.SetIKNeckRigWeight(0, 1f);

//             // if (npc.context.ball.transform.position.y < 0f)
//             // {
//             //     npc.animationController.SetBoolAnimation("Sit_b", false);
//             //     SetRequiredDestinationToBall(npc);
//             //     npc.mover.MoveTo(RequiredDestination.position, npc);
//             // }
//             // if (npc.mover.HasReachedDestination(npc))
//             // {
//             //     npc.animationController.SetBoolAnimation("Sit_b", false);
//             //     npc.context.ball.transform.position = npc.context.player.transform.position;
//             //     SetRequiredDestinationToPlayer(npc);
//             //     npc.mover.MoveTo(RequiredDestination.position, npc);
//             // }
//         }

//         // public void SetRequiredDestinationToPlayer(DogController npc)
//         // {
//         //     RequiredDestination = npc.context.player.transform;
//         //     npc.mover.destination = RequiredDestination;
//         // }

//         // public void SetRequiredDestinationToBall(DogController npc)
//         // {
//         //     RequiredDestination = npc.context.ball.transform;
//         //     npc.mover.destination = RequiredDestination;
//         // }

//         public override void SetRequiredDestination(DogController npc)
//         {
//             // float distanceToBall = Vector3.Distance(npc.context.ball.transform.position, npc.transform.position);
//             // if (distanceToBall > 0.5f)
//             // {
//             RequiredDestination = npc.context.ball.transform;
//             npc.mover.destination = RequiredDestination;
//             // }
//             // else
//             // {
//             //     RequiredDestination = npc.context.player.transform;
//             //     npc.mover.destination = RequiredDestination;
//             // }
//         }

//     }
// }