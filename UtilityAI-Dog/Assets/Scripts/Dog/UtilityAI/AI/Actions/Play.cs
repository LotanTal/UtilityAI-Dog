using System.Collections;
using System.Collections.Generic;
using CorgiTools.Dog.Stats;
using CorgiTools.DogControllers;
using CorgiTools.UtilityAI;
using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Play", menuName = "UtilityAI/Actions/Play")]
    public class Play : AIAction
    {
        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, -20);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, 10);
        }

        public override void SetAnimation(DogController npc)
        {
            npc.animationController.SetValueAnimation("ActionType_int", 13);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogToy.transform;
            npc.mover.destination = RequiredDestination;
        }
        public override void OnFinishedAction(DogController npc)
        {
            base.OnFinishedAction(npc);
            npc.animationController.SetValueAnimation("ActionType_int", 0);
        }
    }
}

