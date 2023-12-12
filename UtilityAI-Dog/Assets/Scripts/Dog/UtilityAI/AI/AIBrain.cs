using UnityEngine;

namespace CorgiTools.UtilityAI
{
    using System.Collections.Generic;
    using System.Linq;
    using CorgiTools.DogControllers;
    using CorgiTools.UtilityAI.Actions;

    public class AIBrain : MonoBehaviour
    {
        public bool finishedDeceding { get; set; }
        public bool finishedExcutingBestAction { get; set; }

        public AIAction bestAction { get; set; }
        private DogController npc;
        [SerializeField] private List<AIAction> actionsAvailable;


        void Start()
        {
            npc = GetComponent<DogController>();
            finishedDeceding = false;
            finishedExcutingBestAction = false;
        }

        public float ScoreAction(AIAction action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Count; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration(npc);
                score *= considerationScore;

                if (score == 0f)
                {
                    action.score = 0f;
                    return action.score;
                }
            }

            float originalScore = score;
            float modFactor = 1 - (1 / action.considerations.Count);
            float makeupValue = (1 - originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;
        }

        public void DecideBestAction()
        {
            finishedExcutingBestAction = false;

            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionsAvailable.Count; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].score;
                }
            }

            bestAction = actionsAvailable[nextBestActionIndex];
            bestAction.SetRequiredDestination(npc);

            finishedDeceding = true;
        }

        /// <summary>
        /// Add an action and its consideration to the list of actions
        /// </summary>
        /// <param name="action">The AI action to be added to the list.</param>
        /// <param name="consideration">The consideration associated with the action.</param>
        public void AddActionsAvailable(AIAction action, Consideration consideration)
        {
            if (!IsActionAvailable(action))
            {
                action.considerations = new List<Consideration>();
                action.considerations.Add(consideration);
                actionsAvailable.Add(action);
            }
        }
        public void RemoveActionsAvailable(AIAction action)
        {
            actionsAvailable.Remove(action);
        }

        public bool IsActionAvailable(AIAction action)
        {
            return actionsAvailable.Any(a => a.GetType() == action.GetType());
        }
    }
}








// public List<AISensor> Sensors = new List<AISensor>();
// public List<AINoise> Noises = new List<AINoise>();
// public List<AIAction> Actions = new list<AIAction>();