using CorgiTools.Core;
using CorgiTools.DogControllers;
using CorgiTools.Dog.Stats;
using UnityEngine;
using CorgiTools.UtilityAI.Actions;
using CorgiTools.UtilityAI;
using CorgiTools.UtilityAI.Considerations;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorgiTools.CorgiEvents
{
    public interface IEvent { }
    public struct OnBasicStatsChangedEvent : IEvent
    {
        public BasicStatsEnum _basicStat { get; private set; }
        public float _value { get; private set; }
        public OnBasicStatsChangedEvent(BasicStatsEnum basicStat, float value)
        {
            _basicStat = basicStat;
            _value = value;
        }
    }

    public struct PlayerPickedUpBall : IEvent
    {
        public PlayerPickedUpBall(DogController dog)
        {
            dog.aiBrain.AddActionsAvailable(ScriptableObject.CreateInstance<PlayWithBall>(), ScriptableObject.CreateInstance<PlayerPickedUpToy>());
            dog.mover.agent.stoppingDistance = 2f;
            dog.aiBrain.bestAction.AbortAction(dog);
            Debug.Log("player picked up ball!");
        }
    }
}
