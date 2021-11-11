using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.collider.tag.Equals("Pickup")) return;
        IIPickupPowerUps pickupPowerUps = other.gameObject.GetComponent<IIPickupPowerUps>();
        if (pickupPowerUps == null) return;
        pickupPowerUps.ExecutePowerUp(gameObject);
    }
}
