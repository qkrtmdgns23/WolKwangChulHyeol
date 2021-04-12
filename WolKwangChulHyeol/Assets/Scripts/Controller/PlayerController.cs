using UnityEngine;
using System.Collections;
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
        
        private void InteractWithMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                GetComponent<Moving>().Move(horizontal, vertical);
            }
            else
            {
                GetComponent<Moving>().Run(horizontal, vertical);
            }
        }

        private void InteractWithRotation()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            GetComponent<Rotation>().Rotate(mouseX, mouseY);
        }
    }
}