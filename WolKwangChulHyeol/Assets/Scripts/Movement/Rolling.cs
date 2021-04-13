using UnityEngine;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Movement
{
    public class Rolling : MonoBehaviour, IAction
    {
        [SerializeField] float rollSpeed = 5.0f;
        [SerializeField] float rollStamina = 10.0f;

        private Stamina stamina;

        public float GetRollStamina()
        {
            return rollStamina; 
        }

        private void Start() {
            stamina = GetComponent<Stamina>();
        }

        public void Roll()
        {
            GetComponent<CharacterController>().Move(Vector3.forward * rollSpeed * Time.deltaTime);
            stamina.TakeStamina(rollStamina);
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            GetComponent<Animator>().SetTrigger("roll");
        }
        
        // IAction Interface 구현
        public void Cancel()
        {

        }
    }
}
