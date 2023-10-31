using UnityEngine;
using UnityEngine.AI;

namespace CorgiTools.DogControllers
{
    public class MoveController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform destination;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 position, DogController npc)
        {
            agent.destination = position;
        }

        public bool HasReachedDestination(DogController npc)
        {
            return Vector3.Distance(npc.aiBrain.bestAction.RequiredDestination.position, agent.transform.position) < agent.stoppingDistance;
        }
    }

}