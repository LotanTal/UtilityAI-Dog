using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class Eat : AIAction
    {
        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, -10);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, 10);
        }

        public override void SetAnimation(DogController npc)
        {
            npc.animationController.SetValueAnimation("ActionType_int", 5);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogBowl.transform;
            npc.mover.destination = RequiredDestination;
        }
        public override void OnFinishedAction(DogController npc)
        {
            base.OnFinishedAction(npc);
            npc.animationController.SetValueAnimation("ActionType_int", 0);

        }
    }
}
