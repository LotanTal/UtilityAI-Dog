using System;
using System.Collections;
using System.Threading.Tasks;
using CorgiTools.Dog.Stats;
using UnityEngine;
using CorgiTools.Debugger;
using CorgiTools.CorgiEvents;

namespace CorgiTools.DogControllers
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] public SO_BasicStats basicStats;
        [SerializeField] public SO_BehavioralStats behavioralStats;

        // sets the init stats for the dog, and updates the UI
        private void Start()
        {
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

    }
}
