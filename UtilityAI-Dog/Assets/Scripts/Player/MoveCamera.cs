using System.Collections;
using System.Collections.Generic;
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

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace CorgiTools.Player
// {
//     public class PlayerMovement : MonoBehaviour
//     {
//         [Header("Movement")]
//         public float moveSpeed;
//         public Transform orientation;
//         float horizontalInput;
//         float verticalInput;
//         Vector3 moveDirection;
//         Rigidbody rb;

//         [Header("Look")]
//         public float sensX;
//         public float sensY;
//         float xRoation;
//         float yRotation;
//         public Transform cameraPos;

//         [Header("Object PickUp")]
//         public Transform pickupPoint; // Point from which we'll throw the object
//         public float throwForce = 10f;
//         private Rigidbody currentObject; // Object we're holding

//         void Start()
//         {
//             rb = GetComponent<Rigidbody>();
//             rb.freezeRotation = true;
//             Cursor.lockState = CursorLockMode.Locked;
//             Cursor.visible = false;
//         }
//         void Update()
//         {
//             HandleMovePosition();
//             HandleLookRotation();
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 if (currentObject == null) // If we're not holding an object, pick it up
//                 {
//                     PickupObject();
//                 }
//                 else // If we're already holding an object, throw it
//                 {
//                     ThrowObject();
//                 }
//             }
//         }
//         void FixedUpdate()
//         {
//             MovePlayer();
//         }

//         private void HandleLookRotation()
//         {
//             float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
//             float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

//             yRotation += mouseX;
//             xRoation -= mouseY;
//             xRoation = Mathf.Clamp(xRoation, -90f, 90f);

//             cameraPos.rotation = Quaternion.Euler(xRoation, yRotation, 0);
//             transform.rotation = Quaternion.Euler(0, yRotation, 0);
//         }

//         private void HandleMovePosition()
//         {
//             horizontalInput = Input.GetAxisRaw("Horizontal");
//             verticalInput = Input.GetAxisRaw("Vertical");
//         }

//         private void MovePlayer()
//         {
//             moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
//             rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
//         }

//         void PickupObject()
//         {
//             Debug.Log("trying to pick up object");
//             RaycastHit hit;
//             // Define the origin, radius, direction, and max distance of the SphereCast
//             Vector3 origin = transform.position;
//             float radius = 10f; // Adjust as needed
//             Vector3 direction = transform.forward;
//             float maxDistance = 10f; // Adjust as needed

//             // Draw the sphere in debug mode to visualize
//             Debug.DrawRay(origin, direction * maxDistance, Color.red, 1f);
//             Debug.DrawLine(origin, origin + direction * radius, Color.blue, 1f);

//             if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance))
//             {
//                 Debug.Log("SphereCast hit: " + hit.collider.name);

//                 Rigidbody hitObjectRb = hit.collider.gameObject.GetComponent<Rigidbody>();
//                 if (hitObjectRb != null)
//                 {
//                     currentObject = hitObjectRb;
//                     currentObject.isKinematic = true;
//                     currentObject.transform.position = pickupPoint.position;
//                     currentObject.transform.rotation = pickupPoint.rotation;
//                     currentObject.transform.parent = pickupPoint;
//                     currentObject.useGravity = false;
//                     currentObject.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//                 }

//             }
//             if (!Physics.SphereCast(origin, radius, direction, out hit, maxDistance))
//             {
//                 Debug.Log("No hit");
//             }
//         }


//         void ThrowObject()
//         {
//             if (currentObject != null)
//             {
//                 currentObject.transform.parent = null; // Unparent the object
//                 currentObject.useGravity = true; // Enable gravity on the object
//                 currentObject.isKinematic = false;

//                 // Apply force to the object to throw it
//                 currentObject.AddForce(pickupPoint.forward * throwForce, ForceMode.VelocityChange);

//                 currentObject = null; // We're no longer holding the object
//             }
//         }
//     }
// }
