using UnityEngine;
using System.Collections;


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

		public float TimeBetweenRotations = 10f;

		public float RotationStep = 45f;

		private int amountOfTurns = 0;
		private float timer;

        private void Start()
        {
            if (rotateDirection == Direction.CCW) rotationSpeed = rotationSpeed * -1;
        }

		private void Update()
		{
			timer += Time.deltaTime;
			if(timer >= TimeBetweenRotations)
			{
				timer = 0f;
				StartCoroutine(RotateRoom());
			}
		}

		private IEnumerator RotateRoom()
		{
			++amountOfTurns;
			float newRotation = RotationStep * amountOfTurns;

			bool finishedRotating = false;
			while (!finishedRotating)
			{
				Debug.Log($"{transform.eulerAngles.z}, {newRotation}");
				transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
				if(transform.eulerAngles.z >= newRotation)
				{
					Debug.Log($"{transform.eulerAngles.z}, {newRotation}");
					transform.eulerAngles = new Vector3 {z = newRotation };
					finishedRotating = true;
				}
				yield return null;
			}
		}
	}
}
