using System.Collections;
using UnityEngine;
using TMPro;
using SerializableDictionary.Scripts;
using CorgiTools.Dog.Stats;
using UnityEngine.UI;
using CorgiTools.CorgiEvents;
namespace CorgiTools.Core
{


    public class Billboard : MonoBehaviour
    {
        public SerializableDictionary<BasicStatsEnum, TMP_Text> basicStatsDICT = new SerializableDictionary<BasicStatsEnum, TMP_Text>();
        public SerializableDictionary<BasicStatsEnum, Slider> basicStatSliderDICT = new SerializableDictionary<BasicStatsEnum, Slider>();
        EventBinding<OnBasicStatsChangedEvent> statsChangedBinding;


        public void UpdateStatsSlider(BasicStatsEnum basicStat, float value)
        {
            StartCoroutine(SmoothSliderChange(basicStat, value, 0.5f));
        }

        IEnumerator SmoothSliderChange(BasicStatsEnum basicStat, float targetValue, float duration)
        {
            float elapsedTime = 0;
            float startingValue = basicStatSliderDICT.Dictionary[basicStat].value;

            while (elapsedTime < duration)
            {
                float newValue = Mathf.Lerp(startingValue, targetValue, elapsedTime / duration);
                basicStatSliderDICT.Dictionary[basicStat].value = newValue;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the target value is reached.
            basicStatSliderDICT.Dictionary[basicStat].value = targetValue;
        }
        private void UpdateStatsSlider(OnBasicStatsChangedEvent e)
        {
            if (basicStatSliderDICT.Dictionary.TryGetValue(e._basicStat, out Slider slider))
            {
                StartCoroutine(SmoothSliderChange(e._basicStat, e._value, 0.5f));
            }
            else
            {
                Debug.LogError($"Slider for {e._basicStat} not found in Dictionary.");
            }
        }


        void OnEnable()
        {
            statsChangedBinding = new EventBinding<OnBasicStatsChangedEvent>(UpdateStatsSlider);
            EventBus<OnBasicStatsChangedEvent>.Register(statsChangedBinding);
        }

        void OnDisable()
        {
            EventBus<OnBasicStatsChangedEvent>.Unregister(statsChangedBinding);
        }
    }
}

