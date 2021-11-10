using UnityEngine;

namespace Environment
{
    public class RotateEnvironment : MonoBehaviour
    {
        public enum Direction
        {
            CW,
            CCW
        }

        public Direction rotateDirection = Direction.CW;
        public float rotationSpeed = 10;

        private void Start()
        {
            if (rotateDirection == Direction.CCW) rotationSpeed = rotationSpeed * -1;
        }
        
        private void Update()
        {
            transform.Rotate( Vector3.forward * ( -rotationSpeed * Time.deltaTime));
        }
    }
}
