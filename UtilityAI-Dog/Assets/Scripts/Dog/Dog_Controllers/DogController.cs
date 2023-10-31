using System.Collections;
using CorgiTools.Dog.Stats;
using CorgiTools.UtilityAI;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.DogControllers
{
    public enum State { decide, move, excute }
    public class DogController : MonoBehaviour
    {
        public MoveController mover { get; set; }
        public StatsController stats;
        public AIBrain aiBrain { get; set; }
        public AnimationController animationController;
        public Context context;
        public State currentState;
        public Billboard billboard;



        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            stats = GetComponent<StatsController>().StatsInit(this);
        }

        void Update()
        {
            FSMTick();
        }

        public void FSMTick()
        {
            animationController.WalkingAnimation(this);

            switch (currentState)
            {
                case State.decide:
                    aiBrain.DecideBestAction();
                    if (!mover.HasReachedDestination(this))
                    {
                        currentState = State.move;
                        mover.MoveTo(aiBrain.bestAction.RequiredDestination.position, this); // Set destination once
                    }
                    else
                    {
                        currentState = State.excute;
                    }
                    break;

                case State.move:
                    if (mover.HasReachedDestination(this))
                    {
                        currentState = State.excute;
                    }
                    break;

                case State.excute:
                    if (!aiBrain.finishedExcutingBestAction)
                    {
                        aiBrain.bestAction.ExecuteAction(this);
                    }
                    else
                    {
                        aiBrain.bestAction.hasExecuted = false;
                        currentState = State.decide;
                    }
                    break;
            }
        }


        public void OnFinishedAction()
        {
            aiBrain.bestAction.OnFinishedAction(this);
        }

        public void UpdateBillboard(BasicStatsEnum basicStat, float value)
        {
            billboard.UpdateStatsSlider(basicStat, value);
        }

        // #region Coroutine



        // public void PrintProgressBar(float value)
        // {
        //     // Normalize the value to be between 0 and 1
        //     float percentage = Mathf.Clamp01(value / 100f);

        //     int totalBars = 50; // Total number of bars in the progress bar
        //     int filledBars = Mathf.RoundToInt(percentage * totalBars); // Number of filled bars based on the percentage

        //     // Create the filled and empty parts of the progress bar
        //     string filledPart = new string('▇', filledBars);
        //     string emptyPart = new string(' ', totalBars - filledBars);

        //     // Print the progress bar to the console
        //     Debug.Log("|" + $"<color=cyan>{filledPart}</color>" + emptyPart + "| " + (percentage * 100).ToString("0.00") + "%");
        // }



        // #endregion
    }
}

