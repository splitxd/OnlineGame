using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerLook : MonoBehaviour
    {
        public Camera cam;
        private float xRotation;
        private float yRotation;
        
        [SerializeField] private float xSensitivity = 30f;
        [SerializeField] private float ySensitivity = 30f;

        public void ProcessLook(Vector2 input)
        {
            float mouseX = input.x;
            float mouseY = input.y;
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSensitivity));
        }
    }
}