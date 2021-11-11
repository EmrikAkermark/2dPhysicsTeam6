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
        [SerializeField]private int bounceAmount = 5;
        private int _hitCount = 0;
        
        private Rigidbody2D _rigidbody2D;
        private GameObject _player; // Player who shot this Projectile
        private bool _hitSomething = false;
        private Vector3 _lastVelocity = Vector3.zero;
        private float _lastFrameSpeed = 0;
        public void Fire(GameObject go)
        {
            // _Player represent the Owner of the bullet , We can later ignore collision with self 
            _player = go;
            var direction =  transform.position - _player.transform.position ;
            direction.Normalize();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _rigidbody2D.AddForce(direction * force);
            Invoke(nameof(DestroyWithDelay),10f); // Failsafe kill 

        }

        private void DestroyWithDelay()
        {
            if(gameObject!=null) Destroy(gameObject);
        }

        private void Update()
        {
            _lastVelocity = _rigidbody2D.velocity;
            if(_rigidbody2D.velocity.magnitude > _lastFrameSpeed) _lastFrameSpeed = _rigidbody2D.velocity.magnitude;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            var desiredDirection = Vector3.Reflect(_lastVelocity.normalized, col.contacts[0].normal);
            _rigidbody2D.velocity = desiredDirection * Mathf.Max(0,_lastFrameSpeed);
            _hitCount++;
            

            // no need for cleaner way as map is too small for anything else to happen.
            GameObject otherPlayer = col.collider.gameObject;
            // If we hit a MonkeyBar Ignore , As we want the bullet to swing too . 
            if(otherPlayer.tag.Equals("Monkeybar")) return;
            

            if (otherPlayer.tag.Equals("Player"))
            {
                // I will release the player , In case the MonkeyBar Script still have the Player Attached
                //  That will lead to a null ref . 
                var playerJumpEvent = new OnPlayerMonkeyBarRelease(otherPlayer,"Player");
                EventManager.SendNewEvent(playerJumpEvent);
                Destroy(otherPlayer);
                Destroy(gameObject);
            }
            if(_hitCount > bounceAmount+1) Destroy(gameObject);
            
        }

   

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
