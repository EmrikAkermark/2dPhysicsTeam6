using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.collider.tag.Equals("Pickup")) return;
    }
}
