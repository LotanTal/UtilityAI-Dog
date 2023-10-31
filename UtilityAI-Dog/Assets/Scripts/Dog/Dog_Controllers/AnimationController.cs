using System.Collections;
using System.Collections.Generic;
using CorgiTools.UtilityAI;
using Unity.VisualScripting;
using UnityEngine;

namespace CorgiTools.DogControllers
{
    public class AnimationController : MonoBehaviour
    {
        public Animator Animator;
        public float maxWalk = 0.5f;
        private float w_movement = 0.0f; // Run value
        public float acceleration = 1.0f;
        public float decelleration = 1.0f;
        public float currentSpeed = 0.0f;

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

        private bool isRotationComplete = true;  // Class-level variable

        public void WalkingAnimation(DogController npc)
        {
            if (isRotationComplete)
            {
                // If the agent has a non-zero velocity, determine its look rotation
                if (npc.mover.agent.velocity != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(npc.transform.forward);
                    Quaternion currentRotation = npc.transform.rotation;

                    // Calculate the angle difference
                    float angle = Quaternion.Angle(currentRotation, lookRotation);

                    // Check if the agent turns around 180 degrees
                    if (Mathf.Abs(angle - 180) < 10)  // Tolerance of 10 degrees
                    {
                        float normalizedAngle = Mathf.Clamp((angle - 90) / 90, 0, 1);
                        Animator.SetFloat("TurnAngle_f", normalizedAngle);
                        StartCoroutine(WaitForRotationAnimationCompletion());
                        return; // Exit the function early so that we don't update the walking animation
                    }
                    else
                    {
                        Animator.SetInteger("TurnAngle_f", 0);
                    }

                    // Now align rotation to path
                    npc.transform.rotation = Quaternion.Slerp(currentRotation, lookRotation, Time.deltaTime * 5);
                }

                // Calculate the desired speed based on the agent's velocity
                float desiredSpeed = npc.mover.agent.velocity.magnitude;

                // Accelerate or decelerate smoothly
                if (currentSpeed < desiredSpeed)
                {
                    currentSpeed += acceleration * Time.deltaTime;
                }
                else if (currentSpeed > desiredSpeed)
                {
                    currentSpeed -= decelleration * Time.deltaTime;
                }

                // Clamp the current speed
                currentSpeed = Mathf.Clamp(currentSpeed, 0, maxWalk);

                // Set the walking animation
                Animator.SetFloat("Movement_f", currentSpeed);
            }
        }

        IEnumerator WaitForRotationAnimationCompletion()
        {
            isRotationComplete = false; // Set the flag to false as we start the rotation animation
                                        // Assuming the rotation animation takes 1 second, wait for 1 second
            yield return new WaitForSeconds(1f);
            isRotationComplete = true; // Set the flag to true after the rotation animation completes
        }
        // private void OnAnimatorIK(int layerIndex)
        // {
        //     if (Animator)
        //     {
        //         HandleIKForTurning();
        //     }
        // }

        // private void HandleIKForTurning()
        // {
        //     DogController npc = GetComponent<DogController>();

        //     if (npc.mover.agent.velocity != Vector3.zero)
        //     {
        //         // Calculate the desired rotation based on the agent's velocity
        //         Quaternion lookRotation = Quaternion.LookRotation(npc.mover.agent.velocity.normalized);

        //         // Find the spine bone or another relevant bone in the dog's skeleton
        //         Transform spineBone = Animator.GetBoneTransform(HumanBodyBones.Spine);
        //         if (spineBone != null)
        //         {
        //             // Calculate the difference between the current rotation and the desired rotation
        //             Quaternion deltaRotation = lookRotation * Quaternion.Inverse(spineBone.rotation);

        //             // Apply the rotation to the spine bone using IK
        //             Animator.SetBoneLocalRotation(HumanBodyBones.Spine, Quaternion.Lerp(Quaternion.identity, deltaRotation, 0.5f));
        //         }
        //     }
        // }



    }
}