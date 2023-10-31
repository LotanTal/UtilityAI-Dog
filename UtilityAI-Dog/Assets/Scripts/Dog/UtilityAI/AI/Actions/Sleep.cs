using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorgiTools.Core;
using CorgiTools.UtilityAI;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/Actions/Sleep")]

    public class Sleep : AIAction
    {

        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, 50);
        }

        public override void SetAnimation(DogController npc)
        {
            npc.animationController.SetBoolAnimation("Sleep_b", true);
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.dogBed.transform;
            npc.mover.destination = RequiredDestination;
        }

        public override void OnFinishedAction(DogController npc)
        {
            base.OnFinishedAction(npc);
            npc.animationController.SetBoolAnimation("Sleep_b", false);
        }
    }
}
