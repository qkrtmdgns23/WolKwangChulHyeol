using UnityEngine;
using WolKwangChulHyeol.Movement;
using WolKwangChulHyeol.Combat;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private Moving moving;
        private Stamina stamina;
        private Rolling rolling;

        private float gaspTime = Mathf.Infinity;

        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            moving = GetComponent<Moving>();
            stamina = GetComponent<Stamina>();
            rolling = GetComponent<Rolling>();
        }

        private void Update()
        {
            if(GetComponent<Health>().IsDead() == true) return;
            if(InteractWithCombat()) return;
            InteractWithRotation();
            InteractWithMovement();
            if(InteractWithTargeting()) return;
            if(InteractWithRolling()) return;         
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

        private bool InteractWithRolling()
        {
            if(Input.GetKeyDown(KeyCode.LeftControl) == true && stamina.GetStamina() > rolling.GetRollStamina())
            {
                rolling.Roll();
                return true;
            }
            return false;
        }

        private bool InteractWithTargeting()
        {
            if(moving.isTargeting == true)
            {
                if(Input.GetKeyDown(KeyCode.Q) == true)
                {
                    moving.isTargeting = false;
                    return false;
                }
                return true;
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.Q) == true)
                {
                    moving.isTargeting = true;
                    return true;
                }
                return false;
            }
        }

        private bool InteractWithCombat()
        {
            if(Input.GetMouseButtonDown(0))
            {
                GetComponent<Fighter>().Attack();
                return true;
            }
            return false;
        }
    }
}