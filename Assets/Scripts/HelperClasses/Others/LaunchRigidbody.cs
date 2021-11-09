using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRigidbody : MonoBehaviour
{
	public Rigidbody2D LaunchBody;
	public float ReleaseAngle = 0f;
	public float Power = 10f;

	public bool LaunchOnStart;

	private Vector2 ReleaseVector;

	private void Start()
	{
		if(LaunchOnStart)
			Launch();
	}


	public void Launch()
	{
		LaunchBody.velocity = ReleaseVector * Power;
	}


	private void OnValidate()
	{
		ReleaseVector = new Vector2 { x = Mathf.Sin(ReleaseAngle * Mathf.Deg2Rad), y = Mathf.Cos(ReleaseAngle * Mathf.Deg2Rad) };
		
	}
}
