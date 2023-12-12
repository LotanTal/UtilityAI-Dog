using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.AnimationStates;
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/Actions/Sleep")]

    public class Sleep : AIAction
    {
        private AnimationStates.AnimationState _animationState = new As_Sleep();
        public override AnimationStates.AnimationState animationState
        {
            get { return _animationState; }
            protected set { _animationState = value; }
        }

        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, 50);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogBed.transform;
            npc.mover.destination = RequiredDestination;
        }
    }
}
