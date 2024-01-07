using System.Collections;
using System.Collections.Generic;
using CorgiTools.UtilityAI;
using Unity.VisualScripting;
using UnityEngine;
using CorgiTools.Dog.Stats;
using UnityEngine.Animations.Rigging;
using CorgiTools.AnimationStates;
using AnimationState = CorgiTools.AnimationStates.AnimationState;

namespace CorgiTools.DogControllers
{
    public class AnimationController : MonoBehaviour
    {
        public Animator Animator;
        public float maxWalk = 1f;
        public float acceleration = 0.1f;
        public float decelleration = 1.0f;
        public float currentSpeed = 0.0f;
        private float currentTurnAngle = 0.0f; // Store the current turn angle for smooth interpolation

        public AnimationState currentAnimationState;
        public MultiAimConstraint IKNeckRig;
        public MultiAimConstraint IKUpperSpineRig;


        public void SetTriggerAnimation(string triggerName)
        {
            Animator.SetTrigger(triggerName);
        }
        public void SetBoolAnimation(string boolName, bool value)
        {
            Animator.SetBool(boolName, value);
        }
        public void SetValueAnimation(string valueName, int value)
        {
            Animator.SetInteger(valueName, value);
        }

        public void Update()
        {
            StartCoroutine(BlinkAnim());
        }

        IEnumerator BlinkAnim()
        {
            SetTriggerAnimation("Blink_tr");
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }

        // private bool isRotationComplete = true;  // Class-level variable

        public void WalkingAnimation(DogController npc)
        {
            float desiredSpeed = npc.mover.agent.velocity.magnitude;
            // float desiredSpeed = npc.mover.agent.desiredVelocity.magnitude;
            // Accelerate or decelerate smoothly
            if (currentSpeed < desiredSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
            else if (currentSpeed > desiredSpeed)
            {
                currentSpeed -= decelleration * Time.deltaTime;
            }

            // Clamp the current speed and set the walking animation
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxWalk);
            // Check if the agent is moving
            if (currentSpeed > 0.1f)
            {
                Vector3 targetDirection = (npc.mover.agent.pathEndPosition - npc.transform.position).normalized;
                float angle = Vector3.SignedAngle(npc.transform.forward, targetDirection, Vector3.up);

                float scaleFactor = 5f;
                float targetAngle = Mathf.Clamp((angle / 180f) * scaleFactor, -1f, 1f);

                // Smoothly interpolate the turn angle
                currentTurnAngle = Mathf.Lerp(currentTurnAngle, targetAngle, Time.deltaTime * 5f);
            }
            else
            {
                // Smoothly interpolate back to 0
                currentTurnAngle = Mathf.Lerp(currentTurnAngle, 0.01f, Time.deltaTime * decelleration);
            }
            if (Animator.GetBool("CanWalk") == false)
            {
                Animator.SetFloat("Movement_f", 0);
                Animator.SetFloat("TurnAngle_f", 0);
            }
            else
            {
                Animator.SetFloat("Movement_f", currentSpeed);
                Animator.SetFloat("TurnAngle_f", currentTurnAngle);
            }
        }

        public void SetIKNeckRigWeight(int index, float weight)
        {
            WeightedTransformArray sourceObjects = IKNeckRig.data.sourceObjects;
            sourceObjects.SetWeight(index, weight);
            IKNeckRig.data.sourceObjects = sourceObjects;
        }
    }
}


// IEnumerator WaitForRotationAnimationCompletion()
// {
//     isRotationComplete = false; // Set the flag to false as we start the rotation animation
//                                 // Assuming the rotation animation takes 1 second, wait for 1 second
//     yield return new WaitForSeconds(1f);
//     isRotationComplete = true; // Set the flag to true after the rotation animation completes
// }

// public void SetIKUpperSpineRigWeight(int index, float weight)
// {
//     WeightedTransformArray sourceObjects = IKUpperSpineRig.data.sourceObjects;
//     sourceObjects.SetWeight(index, weight);
//     IKUpperSpineRig.data.sourceObjects = sourceObjects;
// }

