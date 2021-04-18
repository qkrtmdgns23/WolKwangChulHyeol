using UnityEngine;

namespace WolKwangChulHyeol.Movement
{
    public class Locomotion : MonoBehaviour
    {
        // Field - For character's walking and running
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;

        private float moveSpeed;

        private Vector3 moveDirection;

        // Field - For character's jumping
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity;
        [SerializeField] private float groundCheckDistance;

        [SerializeField] private LayerMask groundMask;

        private bool isGrounded;

        private Vector3 velocity;

        // Reference
        private CharacterController controller;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float zAxis = Input.GetAxis("Vertical");

            moveDirection = new Vector3(0, 0, zAxis);

            if(isGrounded)
            {
                if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {
                    Walk();
                }
                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }
                else if (moveDirection == Vector3.zero)
                {
                    Idle();
                }

                moveDirection *= moveSpeed;

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
            else
            {

            }

            controller.Move(moveDirection * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private void Idle()
        {

        }

        private void Walk()
        {
            moveSpeed = walkSpeed;
        }

        private void Run()
        {
            moveSpeed = runSpeed;
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

}
