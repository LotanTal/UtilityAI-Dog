using System.Collections;
using System.Collections.Generic;
using SerializableDictionary.Scripts;
using UnityEngine;
namespace CorgiTools.Dog.Stats
{
    [CreateAssetMenu(fileName = "BehavioralStats", menuName = "Dog/Stats/Behavioral Stats")]
    public class SO_BehavioralStats : SO_Stats
    {
        public SerializableDictionary<BehavioralStatsEnum, float> behavioralStatsDICT = new SerializableDictionary<BehavioralStatsEnum, float>();
    }
}