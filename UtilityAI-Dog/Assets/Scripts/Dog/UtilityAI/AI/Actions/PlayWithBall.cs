using CorgiTools.Dog.Stats;
using CorgiTools.DogControllers;
using UnityEngine;

namespace CorgiTools.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "PlayWithBall", menuName = "UtilityAI/Actions/Play With Ball")]
    public class PlayWithBall : AIAction
    {

        public override void ExecuteAction(DogController npc)
        {
            SetAnimation(npc);

            if (!hasExecuted)
            {
                AffectStats(npc);
                hasExecuted = true;
            }
        }
        public override void AffectStats(DogController npc)
        {
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Energy, -2);
            npc.stats.basicStats.SetBasicStat(npc.stats.basicStats.basicStatsDICT, BasicStatsEnum.Hunger, 1);
        }

        public override void SetAnimation(DogController npc)
        {
            float distanceToPlayer = Vector3.Distance(npc.context.player.transform.position, npc.transform.position);
            float distanceToBall = Vector3.Distance(npc.context.ball.transform.position, npc.transform.position);

            if (distanceToBall < 3f)
            {
                npc.animationController.SetBoolAnimation("Sit_b", true);

                // SetRequiredDestination to the player, since the ball is close enough
                SetRequiredDestinationToPlayer(npc);
            }
            else
            {
                npc.animationController.SetBoolAnimation("Sit_b", false);

                // Fetch the ball, set the required destination to the ball
                SetRequiredDestinationToBall(npc);
            }
        }

        public void SetRequiredDestinationToPlayer(DogController npc)
        {
            RequiredDestination = npc.context.player.transform;
            npc.mover.destination = RequiredDestination;
        }

        public void SetRequiredDestinationToBall(DogController npc)
        {
            RequiredDestination = npc.context.ball.transform;
            npc.mover.destination = RequiredDestination;
        }

        public override void SetRequiredDestination(DogController npc)
        {
            RequiredDestination = npc.context.ball.transform;
            npc.mover.destination = RequiredDestination;
        }

    }
}