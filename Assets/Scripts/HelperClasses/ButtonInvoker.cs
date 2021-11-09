using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInvoker : MonoBehaviour
{
	public KeyCode Activate;
	public UnityEvent Invoker;

	private void Update()
	{
		if(Input.GetKeyDown(Activate))
		{
			Invoker.Invoke();
		}
	}
}
