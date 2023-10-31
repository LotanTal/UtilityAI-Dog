using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.UtilityAI.Considerations
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "MoneyConsideration", menuName = "UtilityAI/Considerations/Money Consideration")]
    public class MoneyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(DogController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.basicStats.GetBasicStat(BasicStatsEnum.Health, npc.stats.basicStats.basicStatsDICT) / npc.stats.basicStats.maxValue));
            return score;
        }


    }
}