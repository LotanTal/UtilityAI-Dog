using UnityEngine;

namespace CorgiTools.UtilityAI
{
    using CorgiTools.DogControllers;
    public class AIBrain : MonoBehaviour
    {
        public bool finishedDeceding { get; set; }
        public bool finishedExcutingBestAction { get; set; }

        public AIAction bestAction { get; set; }
        private DogController npc;
        [SerializeField] private AIAction[] actionsAvailable;


        void Start()
        {
            npc = GetComponent<DogController>();
            finishedDeceding = false;
            finishedExcutingBestAction = false;
        }

        public float ScoreAction(AIAction action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
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
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;
        }

        public void DecideBestAction()
        {
            finishedExcutingBestAction = false;

            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionsAvailable.Length; i++)
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
    }
}








// public List<AISensor> Sensors = new List<AISensor>();
// public List<AINoise> Noises = new List<AINoise>();
// public List<AIAction> Actions = new list<AIAction>();