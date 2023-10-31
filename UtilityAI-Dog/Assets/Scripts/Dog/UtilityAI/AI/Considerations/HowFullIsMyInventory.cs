using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.UtilityAI.Considerations
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;

    [CreateAssetMenu(fileName = "HowFullIsMyInventory", menuName = "UtilityAI/Considerations/How Full Is My Inventory")]
    public class HowFullIsMyInventory : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(DogController npc)
        {
            score = responseCurve.Evaluate(npc.stats.basicStats.GetBasicStat(BasicStatsEnum.Hunger, npc.stats.basicStats.basicStatsDICT) / npc.stats.basicStats.maxValue);
            return score;
        }
    }
}
