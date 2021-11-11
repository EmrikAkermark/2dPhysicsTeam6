using UnityEngine;

public class PlayerBounce : MonoBehaviour
{

	public float BounceFactor = 1f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.CompareTag("Player"))
		{
			var otherPlayer = collision.collider.GetComponent<Rigidbody2D>();
			var bounceForce = -collision.relativeVelocity * otherPlayer.mass * BounceFactor;
			Debug.DrawRay(otherPlayer.position, bounceForce, Color.red, 2f);

			otherPlayer.AddForce(bounceForce, ForceMode2D.Impulse);
		}

	}
}
