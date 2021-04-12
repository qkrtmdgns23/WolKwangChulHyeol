using UnityEngine;

namespace WolKwangChulHyeol.Movement
{
    public class Moving : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 2.0f;

        private CharacterController characterController;

        private void Start() {
            characterController = GetComponent<CharacterController>();
        }

        // Param x = Horizontal Axis
        // Param y = Vertical Axis
        public void Move(float x, float y)
        {
            // Move  
            Vector3 move = transform.right * x + transform.forward * y;
            characterController.Move(move * movementSpeed * Time.deltaTime);
            
            UpdateAnimator(move);
        }

        private void UpdateAnimator(Vector3 move)
        {
            float localSpeed = Mathf.Clamp(move.magnitude, -0.5f, 0.5f);
            GetComponent<Animator>().SetFloat("speed", localSpeed);
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
