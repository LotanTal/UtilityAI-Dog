using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using CorgiTools.DogControllers;
using UnityEngine;

namespace CorgiTools.UtilityAI
{
    using CorgiTools.DogControllers;
    using CorgiTools.Dog.Stats;
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

        public Consideration[] considerations;

        public Transform RequiredDestination { get; protected set; }

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
        }

        public virtual void OnFinishedAction(DogController npc)
        {
            npc.aiBrain.finishedExcutingBestAction = true;
        }

        // abstract methods
        public abstract void SetAnimation(DogController npc); // make sure to use the correct string for the animation
        public abstract void AffectStats(DogController npc);
        public abstract void SetRequiredDestination(DogController npc); // sets the destination for the mover. the AI will move towards this destination BEFORE executing action
    }
}