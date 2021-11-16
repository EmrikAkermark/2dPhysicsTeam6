using System;
using HelperClasses.Event_System;
using UnityEngine;

public class MonkeyBar : MonoBehaviour
{
	public bool AutoRelease;
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

	private void OnEnable()
	{
		EventManager.RegisterListener<OnPlayerMonkeyBarRelease>(ReleaseFromMonkeyBar);
	}
	private void OnDisable()
	{
		EventManager.UnregisterListener<OnPlayerMonkeyBarRelease>(ReleaseFromMonkeyBar);
	}
	
	private void OnValidate()
	{
		ReleaseVector = new Vector2 { x = Mathf.Cos(ReleaseAngle * Mathf.Deg2Rad), y = Mathf.Sin(ReleaseAngle * Mathf.Deg2Rad) };
		ReleaseVectorMirror = new Vector2 { x = -Mathf.Cos(ReleaseAngle * Mathf.Deg2Rad), y = Mathf.Sin(ReleaseAngle * Mathf.Deg2Rad) };
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
		PlayerController PC = collision.gameObject.GetComponent<PlayerController>();
		if(playerRigidbody != null)
		{
			if(hasAttached || PC.GetIsAttached())
			{
				return;
				Vector2 normal = (Vector2)collision.transform.position - (Vector2)transform.position;
				Vector2 reflection = Vector2.Reflect(playerRigidbody.velocity.normalized, normal.normalized);

				playerRigidbody.velocity = reflection * Math.Max(playerRigidbody.velocity.magnitude, 3f);

				
				ReleaseFromMonkeyBar();
			}
			AttachToMonkeyBarPosition(collision.transform, playerRigidbody);

		}
	}


	public void AttachToMonkeyBarPosition(Transform player, Rigidbody2D rb2d)
	{
		hasAttached = true;
		isReadyToRelease = false;
		attachedPlayer = player;
		attachedRigidbody = rb2d;
		attachedRigidbody.constraints = RigidbodyConstraints2D.None;
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
		PlayerController PC = player.GetComponent<PlayerController>();
		PC.SetIsAttached(true);
	}

	private void FixedUpdate()
	{
		if (!hasAttached || !AutoRelease)
			return;


		CheckRotationDirection();
		if (isReadyToRelease)
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

	private void CheckRotationDirection()
	{
		Vector2 vectorToPlayer = attachedPlayer.position - transform.position;
		if (Vector2.Angle(attachedRigidbody.velocity, Vector2.Perpendicular(vectorToPlayer)) < Vector2.Angle(attachedRigidbody.velocity, Vector2.Perpendicular(-vectorToPlayer)))
		{

			isRotatingClockwise = false;
		}
		else
		{
			isRotatingClockwise = true;
		}
	}


	
	
	public void ReleaseFromMonkeyBar(EventInfo eventInfo = default(EventInfo))
	{
		
		// We calling Release from Player If this is True 
		OnPlayerMonkeyBarRelease OnReleaseEvent = (OnPlayerMonkeyBarRelease)eventInfo;
		if (OnReleaseEvent!=null)
		{
			Debug.Log("returned");
			if (attachedPlayer == null || OnReleaseEvent.GO != attachedPlayer.gameObject) return;
		}
		Debug.Log("attempted release");
		hingeJoint.connectedBody = null;
		attachedPlayer.up = Vector3.up;
		attachedRigidbody.angularVelocity = 0f;
		attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
		PlayerController PC = attachedPlayer.GetComponent<PlayerController>();
		PC.SetIsAttached(false);

		attachedPlayer = null;
		attachedRigidbody = null;
		hasAttached = false;

	}


}
