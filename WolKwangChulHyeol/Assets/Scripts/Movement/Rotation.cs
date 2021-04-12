using UnityEngine;

namespace WolKwangChulHyeol.Movement
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] float mouseSensitivity = 90.0f;

        private float xRotation = 0.0f;

        // Param x = Mouse X Axis
        // Param y = Mouse Y Axis
        public void Rotate(float x, float y)
        {
            float mouseX = x * mouseSensitivity * Time.deltaTime;
            float mouseY = y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
