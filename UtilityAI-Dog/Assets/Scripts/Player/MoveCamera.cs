using UnityEngine;

namespace CorgiTools.Player
{
    public class MoveCamera : MonoBehaviour
    {
        public Transform cameraPos;


        void Update()
        {
            transform.position = cameraPos.position;
        }
    }
}