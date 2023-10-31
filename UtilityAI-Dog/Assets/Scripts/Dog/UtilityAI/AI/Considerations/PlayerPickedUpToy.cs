using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.UtilityAI.Considerations
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "PlayerPickedUpToyConsideration", menuName = "UtilityAI/Considerations/Player Picked Up Toy Consideration")]
    public class PlayerPickedUpToy : Consideration
    {
        bool playerHasToy = false;

        public override float ScoreConsideration(DogController npc)
        {
            if (playerHasToy)
            {
                score = 1;
            }
            else
            {
                score = 0f;
            }
            return score;
        }

        public void PlayerHasToy()
        {
            playerHasToy = true;
            Debug.Log("player picked up ball");
        }
    }
}
