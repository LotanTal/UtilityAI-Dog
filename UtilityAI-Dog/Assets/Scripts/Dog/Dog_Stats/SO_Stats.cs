using System;
using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using CorgiTools.UtilityAI;
using SerializableDictionary.Scripts;
using UnityEngine;
namespace CorgiTools.Dog.Stats
{
    using CorgiTools.DogControllers;

    public abstract class SO_Stats : ScriptableObject
    {

        public float minValue = 0f;
        public float maxValue = 100f;

        public delegate void BasicStatChangedUIHandler(BasicStatsEnum basicStat, float newValue);
        public event BasicStatChangedUIHandler UI_OnBasicStatChanged;
        public delegate void behavioralStatChangedUIHandler(BehavioralStatsEnum behavioralStat, float newValue);
        public event behavioralStatChangedUIHandler UI_OnBehavioralStatChanged;


        //initializes the stats
        public virtual void InitBasicStats(SO_BasicStats basicStats)
        {
            foreach (BasicStatsEnum basicStat in Enum.GetValues(typeof(BasicStatsEnum)))
            {
                SetBasicStat(basicStats.basicStatsDICT, basicStat, 0);
            }
        }
        public virtual void InitBehavioralStats(SO_BehavioralStats behavioralStats)
        {
            foreach (BehavioralStatsEnum behavioralStat in Enum.GetValues(typeof(BehavioralStatsEnum)))
            {
                SetBehaviorStat(behavioralStat, behavioralStats.behavioralStatsDICT, 0);
            }
        }


        // basic stats get; set;
        public virtual float GetBasicStat(BasicStatsEnum basicStat, SerializableDictionary<BasicStatsEnum, float> BasicStatDictionary)
        {
            if (BasicStatDictionary.Dictionary.TryGetValue(basicStat, out float value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"no stat value found for {basicStat} in {name} stats");
                return 0;
            }
        }

        public virtual float SetBasicStat(SerializableDictionary<BasicStatsEnum, float> BasicStatDictionary, BasicStatsEnum basicStat, float value)
        {
            if (BasicStatDictionary.Dictionary.TryGetValue(basicStat, out float currentValue))
            {
                float newValue = currentValue + value;
                float clampedValue = Mathf.Clamp(newValue, minValue, maxValue);

                BasicStatDictionary.Dictionary[basicStat] = clampedValue;
                UI_OnBasicStatChanged?.Invoke(basicStat, clampedValue); // update UI
                return clampedValue;
            }
            else
            {
                Debug.LogError($"no stat value found for {basicStat} in {name} stats");
                return -1f;
            }
        }


        // behavioral stats get; set;
        public virtual float GetBehaviorStat(BehavioralStatsEnum behavioralStat, SerializableDictionary<BehavioralStatsEnum, float> behaviorStatDictionary)
        {
            if (behaviorStatDictionary.Dictionary.TryGetValue(behavioralStat, out float value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"no stat value found for {behavioralStat} in {name} stats");
                return 0;
            }
        }

        public virtual float SetBehaviorStat(BehavioralStatsEnum behavioralStat, SerializableDictionary<BehavioralStatsEnum, float> behaviorStatDictionary, float value)
        {
            if (behaviorStatDictionary.Dictionary.TryGetValue(behavioralStat, out float currentValue))
            {
                float newValue = currentValue + value;
                float clampedValue = Mathf.Clamp(newValue, minValue, maxValue);

                behaviorStatDictionary.Dictionary[behavioralStat] = clampedValue;
                UI_OnBehavioralStatChanged?.Invoke(behavioralStat, clampedValue); // update UI
                return clampedValue;
            }
            else
            {
                Debug.LogError($"no stat value found for {behavioralStat} in {name} stats");
                return -1f;
            }
        }
    }
}
