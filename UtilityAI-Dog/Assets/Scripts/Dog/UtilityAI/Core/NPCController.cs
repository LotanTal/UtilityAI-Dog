using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CorgiTools.UtilityAI;
using System;
using CorgiTools.Dog.Stats;

namespace CorgiTools.Core
{
    public enum State { decide, move, excute }
    public class DogController : MonoBehaviour
    {
        //     public MoveController mover { get; set; }
        //     public NPCInventory Inventory { get; set; }
        //     public Stats stats { get; set; }
        //     public AIBrain aiBrain { get; set; }
        //     public Context context;
        //     // public NPCAction[] actionsAvailable;
        //     public State currentState;

        //     void Start()
        //     {
        //         mover = GetComponent<MoveController>();
        //         aiBrain = GetComponent<AIBrain>();
        //         Inventory = GetComponent<NPCInventory>();
        //         stats = GetComponent<Stats>();
        //     }

        //     void Update()
        //     {
        //         FSMTick();
        //     }

        //     public void FSMTick()
        //     {
        //         if (currentState == State.decide)
        //         {
        //             aiBrain.DecideBestAction();

        //             if (Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position) < 3f)
        //             {
        //                 currentState = State.excute;
        //             }
        //             else
        //             {
        //                 currentState = State.move;
        //             }
        //         }
        //         else if (currentState == State.move)
        //         {
        //             if (Vector3.Distance(aiBrain.bestAction.RequiredDestination.position, this.transform.position) < 3f)
        //             {
        //                 currentState = State.excute;
        //             }
        //             else
        //             {
        //                 mover.MoveTo(aiBrain.bestAction.RequiredDestination.position);
        //             }
        //         }
        //         else if (currentState == State.excute)
        //         {
        //             if (aiBrain.finishedExcutingBestAction == false)
        //             {
        //                 aiBrain.bestAction.Execute(this);
        //             }
        //             else if (aiBrain.finishedExcutingBestAction == true)
        //             {
        //                 currentState = State.decide;
        //             }
        //         }
        //     }

        //     public void OnFinishedAction()
        //     {
        //         aiBrain.DecideBestAction();
        //     }

        //     #region Coroutine
        //     public void DoWork(int time)
        //     {
        //         StartCoroutine(workCoroutine(time));
        //     }
        //     public void DoSleep(int time)
        //     {
        //         StartCoroutine(sleepCoroutine(time));
        //     }


        //     IEnumerator workCoroutine(int time)
        //     {
        //         int counter = time;
        //         while (counter > 0)
        //         {
        //             yield return new WaitForSeconds(1);
        //             counter--;
        //         }

        //         Debug.Log("I AM WORKING!");
        //         Inventory.AddResource(ResourceType.wood, 10);
        //         // OnFinishedAction();
        //         aiBrain.finishedExcutingBestAction = true;

        //     }
        //     IEnumerator sleepCoroutine(int time)
        //     {
        //         int counter = time;
        //         while (counter > 0)
        //         {
        //             yield return new WaitForSeconds(1);
        //             counter--;
        //         }

        //         Debug.Log("I just slept!");
        //         stats.energy += 1;
        //         // OnFinishedAction();
        //         aiBrain.finishedExcutingBestAction = true;
        //     }

        //     #endregion
    }
}
