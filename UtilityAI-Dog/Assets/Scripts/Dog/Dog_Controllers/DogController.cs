using System.Collections;
using CorgiTools.Dog.Stats;
using CorgiTools.UtilityAI;
using CorgiTools.Core;
using UnityEngine;
using CorgiTools;
using CorgiTools.CorgiEvents;
using CorgiTools.UtilityAI.Actions;
using CorgiTools.AnimationStates;

namespace CorgiTools.DogControllers
{
    public enum State { Decide, Move, Execute }
    public class DogController : MonoBehaviour
    {
        public MoveController mover { get; set; }
        public StatsController stats;
        public AIBrain aiBrain { get; set; }
        public AnimationController animationController;
        public Context context;
        public State currentState;
        public Billboard billboard;
        private Vector3 lastDestination;
        public Vector3 LastDestination { get { return lastDestination; } }
        private AIAction lastAction;


        void Awake()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            stats = GetComponent<StatsController>();
            lastDestination = Vector3.positiveInfinity;
            lastAction = null;
        }

        void Update()
        {
            CheckForDestinationChange();
            FSMTick();
        }

        private float stateChangeBufferTime = 0.5f; // Time buffer in seconds
        private float lastStateChangeTime = 0f; // Time since the last state change

        private void CheckForDestinationChange()
        {
            if (aiBrain.bestAction != null &&
                aiBrain.bestAction.RequiredDestination.position != lastDestination &&
                Time.time - lastStateChangeTime > stateChangeBufferTime)
            {
                lastDestination = aiBrain.bestAction.RequiredDestination.position;
                currentState = State.Decide;
                lastStateChangeTime = Time.time; // Update the last state change time
            }
        }

        public void FSMTick()
        {
            animationController.WalkingAnimation(this);
            switch (currentState)
            {
                case State.Decide:
                    DecideAction();
                    break;

                case State.Move:
                    PerformMove();
                    break;

                case State.Execute:
                    ExecuteAction();
                    break;
            }
        }

        private void DecideAction()
        {

            aiBrain.DecideBestAction();

            if (aiBrain.bestAction != null)// && animationController.Animator.GetBool("CanWalk"))
            {
                lastAction = aiBrain.bestAction;
                lastDestination = aiBrain.bestAction.RequiredDestination.position;

                currentState = State.Move;
            }
        }

        private void PerformMove()
        {
            if (animationController.currentAnimationState != null)
            {
                animationController.currentAnimationState.AnimationStateDefualt(animationController);
            }
            if (animationController.Animator.GetBool("CanWalk"))
            {
                mover.MoveTo(lastDestination, this); // Set destination once
            }
            if (mover.HasReachedDestination(this))
            {
                currentState = State.Execute;
            }

        }

        private void ExecuteAction()
        {
            if (aiBrain.bestAction != lastAction)
            {
                currentState = State.Decide;
                return;
            }

            if (!aiBrain.finishedExcutingBestAction)
            {
                aiBrain.bestAction.ExecuteAction(this);
            }
            else
            {
                aiBrain.bestAction.hasExecuted = false;
                currentState = State.Decide;
            }
        }

        public void OnFinishedAction()
        {
            aiBrain.bestAction.OnFinishedAction(this);
        }
    }
}

//             animationController.SetBoolAnimation("IsAllowedToPerform", false);


// animationController.WalkingAnimation(this);

// switch (currentState)
// {
//     case State.Decide:
//         aiBrain.DecideBestAction();
//         if (!mover.HasReachedDestination(this))
//         {
//             currentState = State.Move;
//             mover.MoveTo(aiBrain.bestAction.RequiredDestination.position, this); // Set destination once
//         }
//         else
//         {
//             currentState = State.Excute;
//         }
//         break;

//     case State.Move:
//         if (mover.HasReachedDestination(this))
//         {
//             currentState = State.Excute;
//         }
//         break;

//     case State.Excute:
//         if (!aiBrain.finishedExcutingBestAction)
//         {
//             aiBrain.bestAction.ExecuteAction(this);
//         }
//         else
//         {
//             aiBrain.bestAction.hasExecuted = false;
//             currentState = State.Decide;
//         }
//         break;
// }