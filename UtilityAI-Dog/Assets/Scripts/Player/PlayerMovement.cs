using UnityEngine;

namespace CorgiTools.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed;
        public Transform orientation;
        float horizontalInput;
        float verticalInput;
        Vector3 moveDirection;
        Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }
        void Update()
        {
            MyInput();
        }
        void FixedUpdate()
        {
            MovePlayer();
        }
        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        private void MovePlayer()
        {
            moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }
}
