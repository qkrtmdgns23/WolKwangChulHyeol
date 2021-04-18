using UnityEngine;

namespace WolKwangChulHyeol.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Make a new weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverrideController = null;
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponDamage = 0.0f;
        [SerializeField] float weaponRange = 0.0f;
        [SerializeField] bool isRightWeapon = true;

        public float GetWeaponDamage()
        {
            return weaponDamage;
        }

        public float GetWeaponRange()
        {
            return weaponRange;
        }

        public void Spawn(Transform rightHand, Transform leftHand, Animator animator)
        {
            if(equippedPrefab != null)
            {
                Transform hand = null;
                if(isRightWeapon)
                {
                    hand = rightHand;
                }
                else
                {
                    hand = leftHand;
                }
                
                Instantiate(equippedPrefab, hand);
            }

            if(animatorOverrideController != null)
            {
                animator.runtimeAnimatorController = animatorOverrideController;
            }
        }
    }
}
