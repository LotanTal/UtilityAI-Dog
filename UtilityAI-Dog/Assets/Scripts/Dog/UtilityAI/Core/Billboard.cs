using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SerializableDictionary.Scripts;
using CorgiTools.Dog.Stats;
using UnityEngine.UI;
namespace CorgiTools.Core
{


    public class Billboard : MonoBehaviour
    {
        public SerializableDictionary<BasicStatsEnum, TMP_Text> basicStatsDICT = new SerializableDictionary<BasicStatsEnum, TMP_Text>();
        public SerializableDictionary<BasicStatsEnum, Slider> basicStatSliderDICT = new SerializableDictionary<BasicStatsEnum, Slider>();


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

    }


}
// basicStatsDICT.Dictionary[basicStat].text = $"{basicStat}: {value}";