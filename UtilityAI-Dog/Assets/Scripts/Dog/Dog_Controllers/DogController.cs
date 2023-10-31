using System.Collections;
using System.Collections.Generic;
using CorgiTools.Dog.Stats;
using CorgiTools.UtilityAI;
using CorgiTools.Core;
using UnityEngine;
using CorgiTools;
using Unity.VisualScripting;
using System;

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

        #region Coroutine

        public void DoWork(int time)
        {
            StartCoroutine(workCoroutine(time));
        }
        public void DoSleep(int time)
        {
            StartCoroutine(sleepCoroutine(time));
        }

        IEnumerator workCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }

            Debug.Log("I AM WORKING!");

        }
        IEnumerator sleepCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                stats.basicStats.SetBasicStat(stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, 1);
                yield return new WaitForSeconds(1);
                counter--;
            }

            Debug.Log("I just slept!");
        }

        #endregion
    }
}

