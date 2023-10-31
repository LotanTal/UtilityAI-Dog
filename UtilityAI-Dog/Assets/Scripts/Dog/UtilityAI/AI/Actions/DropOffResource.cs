using System.Collections;
using System.Collections.Generic;
using CorgiTools.Core;
using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "DropOffResource", menuName = "UtilityAI/Actions/Drop Off Resource")]

    public class DropOffResource : AIAction
    {
        public override void AffectStats(DogController npc)
        {
            throw new System.NotImplementedException();
        }


        public override void SetAnimation(DogController npc)
        {
            throw new System.NotImplementedException();
        }

        public override void SetRequiredDestination(DogController npc)
        {
            // RequiredDestination = npc.context.storage.transform;
            // npc.mover.destination = RequiredDestination;
        }
    }
}
