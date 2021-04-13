using UnityEngine;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Movement
{
    public class Moving : MonoBehaviour, IAction
    {
        [SerializeField] float movementSpeed = 3.0f;
        [SerializeField] float runSpeed = 4.5f;
        [SerializeField] float runStamina = 0.1f;

        private CharacterController characterController;
        private Stamina stamina;

        private void Start() {
            characterController = GetComponent<CharacterController>();
            stamina = GetComponent<Stamina>();
        }

        // Param x = Horizontal Axis
        // Param z = Vertical Axis
        public void Move(float x, float z)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * movementSpeed * Time.deltaTime);
            UpdateAnimator(move, 0.5f);
        }

        // Param x = Horizontal Axis
        // Param z = Vertical Axis
        public void Run(float x, float z)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * runSpeed * Time.deltaTime);
            stamina.TakeStamina(runStamina);
            UpdateAnimator(move, 0.75f);
        }

        private void UpdateAnimator(Vector3 move, float threshold)
        {
            float localSpeed = Mathf.Clamp(move.magnitude, -threshold, threshold);
            GetComponent<Animator>().SetFloat("speed", localSpeed);
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
