using System;
using System.Collections;
using System.Threading.Tasks;
using CorgiTools.Dog.Stats;
using UnityEngine;
using CorgiTools.Debugger;

namespace CorgiTools.DogControllers
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] public SO_BasicStats basicStats;
        [SerializeField] public SO_BehavioralStats behavioralStats;
        private DogController dogNPC;


        //sets the init stats for the dog, and updates the UI
        public void StatsInit(DogController npc)
        {
            dogNPC = npc;
            basicStats.InitBasicStats(basicStats);
            behavioralStats.InitBehavioralStats(behavioralStats);
            UpdateEnergyStats();
        }

        private async void UpdateEnergyStats()
        {
            await UpdateEnergyStatsAsync();
        }

        private async Task UpdateEnergyStatsAsync()
        {
            while (true)
            {
                await Awaitable.WaitForSecondsAsync(1f);
                basicStats.SetBasicStat(basicStats.basicStatsDICT, BasicStatsEnum.Energy, -1);
            }
        }

        private void UI_BasicStatChanged(BasicStatsEnum basicStat, float newValue) // an event that is called through SO_Stats "SetBasicStat"
        {
            dogNPC.UpdateBillboard(basicStat, newValue);
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
