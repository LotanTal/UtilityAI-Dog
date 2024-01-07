using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace CorgiTools.DogControllers
{
    public class MoveController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform destination;
        public float speed;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 position, DogController npc)
        {
            // Vector3 _destination = npc.LastDestination;
            if (npc.animationController.Animator.GetBool("CanWalk"))
            {
                agent.destination = npc.LastDestination;
                agent.speed = speed;

                // npc.animationController.WalkingAnimation(npc);
            }
        }

        public bool HasReachedDestination(DogController npc)
        {
            return Vector3.Distance(npc.aiBrain.bestAction.RequiredDestination.position, agent.transform.position) < agent.stoppingDistance;
        }
    }

}

// using System.Collections;
// using System.Collections.Generic;
// using CorgiTools.UtilityAI;
// using Unity.VisualScripting;
// using UnityEngine;
// using CorgiTools.Dog.Stats;
// using UnityEngine.Animations.Rigging;
// using CorgiTools.AnimationStates;
// using AnimationState = CorgiTools.AnimationStates.AnimationState;

// namespace CorgiTools.DogControllers
// {
//     public class AnimationController : MonoBehaviour
//     {
//         public Animator Animator;
//         public float maxWalk = 1f;
//         public float acceleration = 1.0f;
//         public float decelleration = 1.0f;
//         public float currentSpeed = 0.0f;
//         private float currentTurnAngle = 0.0f; // Store the current turn angle for smooth interpolation


//         public AnimationState currentAnimationState;

//         public MultiAimConstraint IKNeckRig;
//         public MultiAimConstraint IKUpperSpineRig;


//         public void SetTriggerAnimation(string triggerName)
//         {
//             Animator.SetTrigger(triggerName);
//         }
//         public void SetBoolAnimation(string boolName, bool value)
//         {
//             Animator.SetBool(boolName, value);
//         }
//         public void SetValueAnimation(string valueName, int value)
//         {
//             Animator.SetInteger(valueName, value);
//         }

//         public void Update()
//         {
//             StartCoroutine(BlinkAnim());
//         }

//         IEnumerator BlinkAnim()
//         {
//             SetTriggerAnimation("Blink_tr");
//             yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
//         }

//         private bool isRotationComplete = true;  // Class-level variable

//         public void WalkingAnimation(DogController npc)
//         {
//             // Check if the agent has a non-zero velocity
//             if (npc.mover.agent.velocity.sqrMagnitude > 0.01f)
//             {
//                 Vector3 desiredDirection = npc.mover.agent.velocity.normalized;
//                 Vector3 currentForward = npc.transform.forward;

//                 // Calculate the signed angle between the current and desired directions
//                 float angle = Vector3.SignedAngle(currentForward, desiredDirection, Vector3.up);

//                 // Scale factor to adjust the sensitivity of the turn angle
//                 float scaleFactor = 5f; // Adjust as necessary
//                 float targetAngle = Mathf.Clamp((angle / 180f) * scaleFactor, -1f, 1f);

//                 // Smoothly interpolate the turn angle
//                 currentTurnAngle = Mathf.Lerp(currentTurnAngle, targetAngle, Time.deltaTime * 5f);
//                 Animator.SetFloat("TurnAngle_f", currentTurnAngle);

//                 // Align rotation to the desired direction
//                 Quaternion lookRotation = Quaternion.LookRotation(desiredDirection);
//                 npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, lookRotation, Time.deltaTime * 5);
//             }



//             // Calculate the desired speed based on the agent's velocity
//             float desiredSpeed = npc.mover.agent.velocity.magnitude;

//             // Accelerate or decelerate smoothly
//             if (currentSpeed < desiredSpeed)
//             {
//                 currentSpeed += acceleration * Time.deltaTime;
//             }
//             else if (currentSpeed > desiredSpeed)
//             {
//                 currentSpeed -= decelleration * Time.deltaTime;
//             }

//             // Clamp the current speed and set the walking animation
//             currentSpeed = Mathf.Clamp(currentSpeed, 0, maxWalk);
//             Animator.SetFloat("Movement_f", currentSpeed);
//         }






//         IEnumerator WaitForRotationAnimationCompletion()
//         {
//             isRotationComplete = false; // Set the flag to false as we start the rotation animation
//                                         // Assuming the rotation animation takes 1 second, wait for 1 second
//             yield return new WaitForSeconds(1f);
//             isRotationComplete = true; // Set the flag to true after the rotation animation completes
//         }
//         public void SetIKNeckRigWeight(int index, float weight)
//         {
//             WeightedTransformArray sourceObjects = IKNeckRig.data.sourceObjects;
//             sourceObjects.SetWeight(index, weight);
//             IKNeckRig.data.sourceObjects = sourceObjects;
//         }
//         public void SetIKUpperSpineRigWeight(int index, float weight)
//         {
//             WeightedTransformArray sourceObjects = IKUpperSpineRig.data.sourceObjects;
//             sourceObjects.SetWeight(index, weight);
//             IKUpperSpineRig.data.sourceObjects = sourceObjects;
//         }

//     }
// }