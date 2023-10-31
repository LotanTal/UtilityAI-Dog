using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorgiTools.Core;
using CorgiTools.UtilityAI;

namespace CorgiTools.UtilityAI.Actions
{
    using CorgiTools.Dog.Stats;
    using CorgiTools.DogControllers;
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAI/Actions/Work")]
    public class Work : AIAction
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
            float distance = Mathf.Infinity;
            Transform nearestResource = null;

            List<Transform> resources = npc.context.Destinations[DestinationType.Food];
            foreach (Transform resource in resources)
            {
                float distanceFormResource = Vector3.Distance(resource.position, npc.transform.position);
                if (distanceFormResource < distance)
                {
                    nearestResource = resource;
                    distance = distanceFormResource;
                }
            }

            RequiredDestination = nearestResource;
            npc.mover.destination = RequiredDestination;

        }

    }
}
