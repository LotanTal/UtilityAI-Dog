using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CorgiTools.Player
{
    public class PlayerCam : MonoBehaviour
    {
        [Header("Object PickUp")]
        public Transform pickupPoint; // Point from which we'll throw the object
        public float throwForce = 10f;
        private Rigidbody currentObject; // Object we're holding

        public float sensX;
        public float sensY;

        public Transform player;
        float xRoation;
        float yRotation;
        public UnityEvent ToyPickUpHandler;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRoation -= mouseY;
            xRoation = Mathf.Clamp(xRoation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRoation, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);

            // When the player presses the 'SPACE' key, they pick up or throw the object
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentObject == null)
                {
                    PickupObject();
                }
                else
                {
                    ThrowObject();
                }
            }
        }
        void PickupObject()
        {
            RaycastHit hit;
            Vector3 origin = transform.position;
            float radius = 1f;
            Vector3 direction = transform.forward;
            float maxDistance = 10f;

            if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance))
            {
                Debug.Log("SphereCast hit: " + hit.collider.name);

                Rigidbody hitObjectRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (hitObjectRb != null)
                {
                    currentObject = hitObjectRb;
                    currentObject.isKinematic = true;
                    currentObject.transform.SetPositionAndRotation(pickupPoint.position, pickupPoint.rotation);
                    currentObject.transform.parent = pickupPoint;
                }

                if (hit.collider.tag == "Toy")
                {
                    ToyPickUpHandler.Invoke();
                }
            }
        }


        void ThrowObject()
        {
            if (currentObject != null)
            {
                currentObject.transform.parent = null;
                currentObject.useGravity = true;
                currentObject.isKinematic = false;

                // Apply force to the object to throw it
                currentObject.AddForce(pickupPoint.forward * throwForce, ForceMode.VelocityChange);

                currentObject = null;
            }
        }
    }
}

