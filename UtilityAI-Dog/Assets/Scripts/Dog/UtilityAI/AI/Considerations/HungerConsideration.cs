using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.UtilityAI.Considerations
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "HungerConsideration", menuName = "UtilityAI/Considerations/Hunger Consideration")]
    public class HungerConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(DogController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.basicStats.GetBasicStat(BasicStatsEnum.Hunger, npc.stats.basicStats.basicStatsDICT) / npc.stats.basicStats.maxValue));
            return score;
        }


    }
}
