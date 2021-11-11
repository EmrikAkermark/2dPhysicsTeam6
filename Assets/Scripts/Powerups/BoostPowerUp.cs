using Interfaces;
using UnityEngine;

namespace Powerups
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]

    public class BoostPowerUp : MonoBehaviour, IIPickupPowerUps
    {
        [SerializeField] private  float boostMultiplier= 1.5f;
        public void ExecutePowerUp(GameObject player)
        {
            var rigidBody2d = player.GetComponent<Rigidbody2D>();
            if(rigidBody2d == null) return;
            var velocity = rigidBody2d.velocity;
            print(velocity);
            rigidBody2d.velocity = velocity * boostMultiplier;
            print(velocity);
            Destroy(gameObject);
        }
    }
}
