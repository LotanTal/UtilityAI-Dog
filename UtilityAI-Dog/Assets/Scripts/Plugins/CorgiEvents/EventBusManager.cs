using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorgiTools.DogControllers;
using UnityEngine;
namespace CorgiTools.CorgiEvents
{
    public class EventBusManager : MonoBehaviour
    {
        // public DogController dog;

        // EventBinding<PlayerPickedUpBall> ToyPickUpHandler;

        // public void BallPickedUp(PlayerPickedUpBall pickedUpBall)
        // {
        //     // ballPickedUpAsync(pickedUpBall);
        //     pickedUpBall.onEvent(dog);
        // }
        // // public async void ballPickedUpAsync(PlayerPickedUpBall pickedUpBall)
        // // {
        // //     await pickedUpBall.onEvent(dog);
        // // }

        // void OnEnable()
        // {
        //     ToyPickUpHandler = new EventBinding<PlayerPickedUpBall>(BallPickedUp);
        //     EventBus<PlayerPickedUpBall>.Register(ToyPickUpHandler);
        // }
        // void OnDisable()
        // {
        //     EventBus<PlayerPickedUpBall>.Unregister(ToyPickUpHandler);
        // }
    }
}