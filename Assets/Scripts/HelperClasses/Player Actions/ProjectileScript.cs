using System;
using HelperClasses.Event_System;
using Unity.VisualScripting;
using UnityEngine;

namespace HelperClasses.Player_Actions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileScript : MonoBehaviour
    {
        [SerializeField]private float force = 1000;
        private Rigidbody2D _rigidbody2D;
        private GameObject _player; // Player who shot this Projectile
        private bool _HitSomething = false;
        private Vector3 _velocityHitSpeed = Vector3.zero;
        public void Fire(GameObject go)
        {
            // _Player represent the Owner of the bullet , We can later ignore collision with self 
            _player = go;
            var direction =  transform.position - _player.transform.position ;
            direction.Normalize();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _rigidbody2D.AddForce(direction * force);
            Invoke(nameof(DestroyWithDelay),2f);

        }

        private void DestroyWithDelay()
        {
            if(gameObject!=null) Destroy(gameObject);
        }
        
        void OnCollisionEnter2D(Collision2D col)
        {
            if(_HitSomething) return; // Destroying with delay ( For looks ) so hit is counted once when the shot is fired . 

            // no need for cleaner way as map is too small for anything else to happen.
            GameObject otherPlayer = col.collider.gameObject;
            // If we hit a MonkeyBar Ignore , As we want the bullet to swing too . 
            if(otherPlayer.tag.Equals("Monkeybar")) return;
            
            _HitSomething = true;

            if (otherPlayer.tag.Equals("Player"))
            {
                // I will release the player , In case the MonkeyBar Script still have the Player Attached
                //  That will lead to a null ref . 
                var playerJumpEvent = new OnPlayerMonkeyBarRelease(otherPlayer,"Player");
                EventManager.SendNewEvent(playerJumpEvent);
                Destroy(otherPlayer);
                Destroy(gameObject);
             
            }
            else
            {
                _velocityHitSpeed = _rigidbody2D.velocity;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            print("I am exiting the collision");
            _rigidbody2D.velocity =  _rigidbody2D.velocity * 100;
            
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
