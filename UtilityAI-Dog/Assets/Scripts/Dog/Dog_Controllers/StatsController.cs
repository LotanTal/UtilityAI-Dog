using System.Collections;
using CorgiTools.Dog.Stats;
using UnityEngine;

namespace CorgiTools.DogControllers
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] public SO_BasicStats basicStats;
        [SerializeField] public SO_BehavioralStats behavioralStats;
        private DogController dogNPC;


        //sets the init stats for the dog, and updates the UI
        public StatsController StatsInit(DogController npc)
        {
            dogNPC = npc;
            basicStats.InitBasicStats(basicStats);
            behavioralStats.InitBehavioralStats(behavioralStats);
            StartCoroutine(UpdateEnergyStatsCoroutine()); // starts coroutine for the energy to drop every x seconds
            return this;
        }

        private void UI_BasicStatChanged(BasicStatsEnum basicStat, float newValue) // an event that is called through SO_Stats "SetBasicStat"
        {
            dogNPC.UpdateBillboard(basicStat, newValue);
        }

        private IEnumerator UpdateEnergyStatsCoroutine()
        {
            while (true)
            {
                // dogNPC.PrintProgressBar(basicStats.GetBasicStat(BasicStatsEnum.Energy, basicStats.basicStatsDICT));
                yield return new WaitForSeconds(1f);
                basicStats.SetBasicStat(basicStats.basicStatsDICT, BasicStatsEnum.Energy, -1);
            }
        }

        private void OnDisable()
        {
            basicStats.UI_OnBasicStatChanged -= UI_BasicStatChanged;
        }
        private void OnEnable()
        {
            basicStats.UI_OnBasicStatChanged += UI_BasicStatChanged;
        }
    }
}
