using UnityEngine;
using WolKwangChulHyeol.Movement;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private Moving moving;
        private Stamina stamina;

        private float gaspTime = Mathf.Infinity;

        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            moving = GetComponent<Moving>();
            stamina = GetComponent<Stamina>();
        }

        private void Update()
        {
            InteractWithMovement();
            InteractWithRotation();

            gaspTime += Time.deltaTime;
        }

        private void CheckGasp()
        {
            if (stamina.GetStamina() == 0)
            {
                gaspTime = 0.0f;
            }
        }

        private void InteractWithMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) == true && gaspTime > 3.0f)
            {
                CheckGasp();
                moving.Run(horizontal, vertical);
            }
            else
            {
                moving.Move(horizontal, vertical);
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