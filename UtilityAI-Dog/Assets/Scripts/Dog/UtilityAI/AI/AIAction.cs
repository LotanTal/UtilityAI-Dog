using UnityEngine;

namespace CorgiTools.UtilityAI
{
    using System.Collections.Generic;
    using CorgiTools.DogControllers;
    using CorgiTools.AnimationStates;

    public abstract class AIAction : ScriptableObject
    {
        public string Name;

        private float _score;
        public float score
        {
            get { return _score; }
            set { this._score = Mathf.Clamp01(value); }
        }
        public bool hasExecuted { get; set; }

        public List<Consideration> considerations;

        public Transform RequiredDestination { get; protected set; }

        public abstract AnimationState animationState { get; protected set; }


        public virtual void Awake()
        {
            hasExecuted = false;
            score = 0;
        }

        // base methods
        public virtual void ExecuteAction(DogController npc)
        {
            SetAnimation(npc);

            if (!hasExecuted)
            {
                AffectStats(npc);
                hasExecuted = true;
            }
        }

        public virtual void AbortAction(DogController npc)
        {
            hasExecuted = false;
            OnFinishedAction(npc);
            if (npc.aiBrain.bestAction != null && State.Execute == npc.currentState)
            {
                npc.animationController.currentAnimationState.AnimationStateDefualt(npc.animationController);
            }
            if (State.Move == npc.currentState)
            {
                npc.currentState = State.Decide;
            }

        }

        public virtual void OnFinishedAction(DogController npc)
        {
            npc.aiBrain.finishedExcutingBestAction = true;
        }

        public virtual void SetAnimation(DogController npc)
        {
            npc.animationController.currentAnimationState = animationState;

            animationState.SetAnimation(npc.animationController);
        }

        // abstract methods
        public abstract void AffectStats(DogController npc);
        public abstract void SetRequiredDestination(DogController npc); // sets the destination for the mover. the AI will move towards this destination BEFORE executing action
    }
}