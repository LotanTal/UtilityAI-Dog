using CorgiTools.AnimationStates;
using CorgiTools.Dog.Stats;
using CorgiTools.DogControllers;
using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Play", menuName = "UtilityAI/Actions/Play")]
    public class Play : AIAction
    {
        private AnimationStates.AnimationState _animationState = new As_Play();
        public override AnimationStates.AnimationState animationState
        {
            get { return _animationState; }
            protected set { _animationState = value; }
        }

        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, -20);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, 10);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogToy.transform;
            npc.mover.destination = RequiredDestination;
        }
    }
}

