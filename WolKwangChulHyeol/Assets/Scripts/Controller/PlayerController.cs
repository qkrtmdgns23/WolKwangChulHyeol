using UnityEngine;
using WolKwangChulHyeol.Movement;

namespace WolKwangChulHyeol.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update() {
            InteractWithMovement();
            InteractWithRotation();
        }
        
        void InteractWithMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            GetComponent<Moving>().Move(horizontal, vertical);       
        }

        void InteractWithRotation()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            GetComponent<Rotation>().Rotate(mouseX, mouseY);
        }
    }
}