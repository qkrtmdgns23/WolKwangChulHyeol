using UnityEngine;
using WolKwangChulHyeol.Core;

namespace WolKwangChulHyeol.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] Weapon defaultWeapon;
        [SerializeField] Transform rightHand;
        [SerializeField] Transform leftHand;
        [SerializeField] float intervalForComboAttack;

        private float timeSinceLastAttack = Mathf.Infinity;
        private int comboAttack = 0;
        private Animator animator;
 
        private void Start() {
            animator = GetComponent<Animator>();
            defaultWeapon.Spawn(rightHand, leftHand, animator);
        }

        private void Update() {
            timeSinceLastAttack += Time.deltaTime;
            comboAvailable();
        }

        public void Attack()
        {
            timeSinceLastAttack = 0.0f;
            animator.SetBool("isAttack", true);
        }

        private bool comboAvailable()
        {
            if(timeSinceLastAttack < intervalForComboAttack)
            {
                return true;
            }
            else
            {
                Cancel();
                return false;
            }
        }

        public void Cancel()
        {
            comboAttack = 0;
            animator.SetBool("isAttack", false);
            animator.SetInteger("combo", comboAttack);
        }

        private void Hit()
        {

        }
    }
}
