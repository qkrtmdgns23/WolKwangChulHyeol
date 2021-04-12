using UnityEngine;
using System.Collections;

namespace WolKwangChulHyeol.Core
{   
    public class Stamina : MonoBehaviour {
        [SerializeField] float staminaPoints = 100.0f;
        [SerializeField] float restoreQuantity = 2.0f;

        public float GetStamina()
        {
            return staminaPoints;
        }

        private void Start() {
            StartCoroutine(RestoreStamina());
        }

        // Param energy = The quantity to reduce stamina
        public void TakeStamina(float energy)
        {
            staminaPoints = Mathf.Max(staminaPoints - energy, 0);
        }

        private IEnumerator RestoreStamina()
        {
            while(true)
            {
                print(staminaPoints);
                staminaPoints = Mathf.Min(staminaPoints + restoreQuantity, 100.0f);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
