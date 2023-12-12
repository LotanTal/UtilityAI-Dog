using System.Collections;
using System.Collections.Generic;
using CorgiTools.DogControllers;
using CorgiTools.UtilityAI;
using CorgiTools.UtilityAI.Actions;
using UnityEngine;
using CorgiTools;

public class ToPlayReady : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var DogController = FindAnyObjectByType<DogController>();
        Debug.Log("found character");

        var playWithBall = FindAnyObjectByType<PlayWithBall>();
        Debug.Log("found ball");

        if (DogController.aiBrain.IsActionAvailable(playWithBall))
        {
            Debug.Log("found playwithball");
            playWithBall.FetchBall(DogController);
            // DogController.animationController.Animator.StopPlayback();
            Debug.Log("finished");
        }

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
