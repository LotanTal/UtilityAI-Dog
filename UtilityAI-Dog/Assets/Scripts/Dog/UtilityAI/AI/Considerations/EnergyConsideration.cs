using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using CorgiTools.UtilityAI;
using UnityEngine;

namespace CorgiTools.UtilityAI.Considerations
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;

    [CreateAssetMenu(fileName = "EnergyConsideration", menuName = "UtilityAI/Considerations/Energy Consideration")]
    public class EnergyConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;

        public override float ScoreConsideration(DogController npc)
        {
            score = responseCurve.Evaluate(Mathf.Clamp01(npc.stats.basicStats.GetBasicStat(BasicStatsEnum.Energy, npc.stats.basicStats.basicStatsDICT) / npc.stats.basicStats.maxValue));
            return score;
        }
    }
}