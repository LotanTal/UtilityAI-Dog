using SerializableDictionary.Scripts;
using UnityEngine;
namespace CorgiTools.Dog.Stats
{
    [CreateAssetMenu(fileName = "BasicStats", menuName = "Dog/Stats/Basic Stats")]
    public class SO_BasicStats : SO_Stats
    {
        public SerializableDictionary<BasicStatsEnum, float> basicStatsDICT = new SerializableDictionary<BasicStatsEnum, float>();
    }
}