using System.Collections.Generic;
using UnityEngine;

namespace CorgiTools.Core
{
    public enum DestinationType { rest, Toy, Food, Ball }
    public class Context : MonoBehaviour
    {
        public GameObject dogBowl;
        public GameObject dogBed;
        public GameObject dogToy;
        public GameObject ball;
        public GameObject player;

        public Dictionary<DestinationType, List<Transform>> Destinations { get; private set; }

        void Start()
        {
            List<Transform> restDestinations = new List<Transform>() { dogBed.transform };
            List<Transform> eatingDestinations = new List<Transform>() { dogBowl.transform };
            List<Transform> playDestinations = new List<Transform>() { dogToy.transform };
            List<Transform> BallDestinations = new List<Transform>() { ball.transform };


            Destinations = new Dictionary<DestinationType, List<Transform>>()
            {
                {DestinationType.rest, restDestinations},
                {DestinationType.Toy, playDestinations},
                {DestinationType.Food, eatingDestinations},
                {DestinationType.Ball, BallDestinations}
            };
        }
    }
}
