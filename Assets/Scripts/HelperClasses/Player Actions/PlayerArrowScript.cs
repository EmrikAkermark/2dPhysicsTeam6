using System;
using UnityEngine;

namespace HelperClasses.Player_Actions
{

    public class PlayerArrowScript : MonoBehaviour
    {
        private GameObject _player;
        private Transform _projectileArrowTransform;
        public float speedOfOrbit = 10.0f;
        

        private void Start()
        {
            _projectileArrowTransform = transform;
            _player = _projectileArrowTransform.parent.gameObject;
        }
        
        private void Update()
        {
            transform.RotateAround(_player.transform.position, Vector3.forward, -speedOfOrbit * Time.deltaTime);
        }
    }
}
