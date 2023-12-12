using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.AnimationStates;
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class Eat : AIAction
    {
        private AnimationStates.AnimationState _animationState = new As_Eat();
        public override AnimationStates.AnimationState animationState
        {
            get { return _animationState; }
            protected set { _animationState = value; }
        }

        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, -10);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, 10);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogBowl.transform;
            npc.mover.destination = RequiredDestination;
        }
    }
}
