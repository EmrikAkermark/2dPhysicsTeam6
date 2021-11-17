using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
	private GameObject p1, p2;

    // Start is called before the first frame update
    void Start()
    {
		p1 = HelperClasses.Managers.GManager.GetPlayer1();
		p2 = HelperClasses.Managers.GManager.GetPlayer2();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == p1)
		{
			Debug.Log("Player 1 died");
			HelperClasses.Managers.GManager.RespawnPlayer(p1);
		}
		else if(collision.gameObject == p2)
		{
			Debug.Log("Player 2 died");
			HelperClasses.Managers.GManager.RespawnPlayer(p2);
		}
	}
}
