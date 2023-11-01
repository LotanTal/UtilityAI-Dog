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
            stats = GetComponent<StatsController>();
            stats.StatsInit(this);
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
    }
}

