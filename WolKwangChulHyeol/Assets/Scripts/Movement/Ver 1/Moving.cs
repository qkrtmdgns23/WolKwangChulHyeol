using UnityEngine;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Movement
{
    public class Moving : MonoBehaviour, IAction
    {
        [SerializeField] float movementSpeed = 3.0f;
        [SerializeField] float runSpeed = 4.5f;
        [SerializeField] float runStamina = 0.1f;
        [SerializeField] float targetingSpeedRate = 0.8f;

        private Animator animator;
        private CharacterController characterController;
        private Stamina stamina;
        
        public bool isTargeting = false;

        private void Start() {
            characterController = GetComponent<CharacterController>();
            stamina = GetComponent<Stamina>();
            animator = GetComponent<Animator>();
        }

        // Param x = Horizontal Axis
        // Param z = Vertical Axis
        public void Move(float x, float z)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            if(isTargeting == false)
            {
                characterController.Move(move * movementSpeed * Time.deltaTime);
                UpdateAnimator(x, z);
            }
            else
            {
                characterController.Move(move * targetingSpeedRate * movementSpeed * Time.deltaTime);
                UpdateAnimator(x, z);
            }
        }

        // Param x = Horizontal Axis
        // Param z = Vertical Axis
        public void Run(float x, float z)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * runSpeed * Time.deltaTime);
            stamina.TakeStamina(runStamina);
            UpdateAnimator(x * 1.5f, z * 1.5f);
        }

        private void UpdateAnimator(float x, float z)
        {
            if(isTargeting == true)
            {
                animator.SetBool("isFocusOn", true);
            }
            else
            {
                animator.SetBool("isFocusOn", false);
            }

            animator.SetFloat("speedX", x, 0.1f, Time.deltaTime);
            animator.SetFloat("speedZ", z, 0.1f, Time.deltaTime);
        }

        // IAction Interface 구현
        public void Cancel()
        {
            characterController.Move(Vector3.zero);
        }

        // Animator Trigger Value
        void FootR()
        {

        }

        // Animator Trigger Value
        void FootL()
        {

        }
    }
}
