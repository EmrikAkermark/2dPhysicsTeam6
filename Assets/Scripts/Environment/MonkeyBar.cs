using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBar : MonoBehaviour
{
	public float ReleaseAngle = 45f;
	public float DistanceFromMonkeyBar = 1f;

	private Transform attachedPlayer;
	private Rigidbody2D attachedRigidbody;
	private HingeJoint2D hingeJoint;

	private bool hasAttached;
	private bool isRotatingClockwise;
	private bool isReadyToRelease;

	private Vector2 ReleaseVector, ReleaseVectorMirror;




	private void Start()
	{
		hingeJoint = GetComponentInChildren<HingeJoint2D>();
	}

	private void OnValidate()
	{
		ReleaseVector = new Vector2 { x = Mathf.Cos(ReleaseAngle * Mathf.Deg2Rad), y = Mathf.Sin(ReleaseAngle * Mathf.Deg2Rad) };
		ReleaseVectorMirror = new Vector2 { x = -Mathf.Cos(ReleaseAngle * Mathf.Deg2Rad), y = Mathf.Sin(ReleaseAngle * Mathf.Deg2Rad) };
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

		if(playerRigidbody != null)
		{
			AttachToMonkeyBarPosition(collision.transform, playerRigidbody);
		}
	}


	public void AttachToMonkeyBarPosition(Transform player, Rigidbody2D rb2d)
	{
		hasAttached = true;
		isReadyToRelease = false;
		attachedPlayer = player;
		attachedRigidbody = rb2d;
		Vector2 vectorToPlayer = attachedPlayer.position - transform.position;

		vectorToPlayer = vectorToPlayer.normalized * DistanceFromMonkeyBar;
		Debug.Log($"{vectorToPlayer}, {vectorToPlayer.normalized}, {vectorToPlayer.magnitude}");

		attachedPlayer.position = transform.position + (Vector3)vectorToPlayer;

		if (Vector2.Angle(attachedRigidbody.velocity, Vector2.Perpendicular(vectorToPlayer)) < Vector2.Angle(attachedRigidbody.velocity, Vector2.Perpendicular(-vectorToPlayer)))
		{
			rb2d.velocity = Vector2.Perpendicular(vectorToPlayer) * attachedRigidbody.velocity.magnitude;
			isRotatingClockwise = false;
		}
		else
		{
			rb2d.velocity = Vector2.Perpendicular(-vectorToPlayer) * attachedRigidbody.velocity.magnitude;
			isRotatingClockwise = true;
		}

		attachedPlayer.up = -vectorToPlayer;
		hingeJoint.connectedBody = attachedRigidbody;
		
	}

	private void FixedUpdate()
	{
		if (!hasAttached)
			return;

		if(isReadyToRelease)
		{
			CheckIfRelease();
		}
		else
		{
			CheckIfReady();
		}

	}

	private void CheckIfRelease()
	{
		if (isRotatingClockwise)
		{
			if (Vector2.SignedAngle(ReleaseVectorMirror, -attachedPlayer.right) < 0f)
			{
				ReleaseFromMonkeyBar();
			}
		}
		else
		{
			if (Vector2.SignedAngle(ReleaseVector, attachedPlayer.right) > 0f)
			{
				ReleaseFromMonkeyBar();
			}
		}
	}

	private void CheckIfReady()
	{
		if(isRotatingClockwise)
		{
			if (Vector2.SignedAngle(ReleaseVectorMirror, -attachedPlayer.right) > 0f)
			{
				isReadyToRelease = true;
			}
		}
		else
		{
			
			if (Vector2.SignedAngle(ReleaseVector, attachedPlayer.right) < 0f)
			{
				isReadyToRelease = true;
			}
		}
	}


	public void ReleaseFromMonkeyBar()
	{
		hingeJoint.connectedBody = null;
		attachedPlayer.up = Vector3.up;
		attachedRigidbody.angularVelocity = 0f;

		attachedPlayer = null;
		attachedRigidbody = null;
		hasAttached = false;
	}


}
