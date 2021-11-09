using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // public Vector2 velocity;
    
    [SerializeField] private int movementAcceleration = 20;
    [SerializeField] private int jumpAcceleration = 10;
    [Space]
    [SerializeField] private float maxHorizontalVelocity = 10;
    [Space]
    [SerializeField, Range(0f, 5f)] private float airSteeringModifier = .2f;
    [Space]
    [SerializeField, Range(0f, 10f)] private float dragGroundedMoving = 1f;
    [SerializeField, Range(0f, 10f)] private float dragGroundedIdle = 10f;
    [SerializeField, Range(0f, 10f)] private float dragInAirMoving = .5f;
    [SerializeField, Range(0f, 10f)] private float dragInAirIdle = 1f;
    
    private Rigidbody2D rb;
    private float _inputHorizontal = 0f;
    private bool _jump = false;
    private bool _isGrounded = false;
    private bool _isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _isMoving = _inputHorizontal != 0;
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) _jump = true;

        if (_isGrounded && _isMoving) rb.drag = dragGroundedMoving;
        else if (_isGrounded && !_isMoving) rb.drag = dragGroundedIdle;
        else if (!_isGrounded && _isMoving) rb.drag = dragInAirMoving;
        else rb.drag = dragInAirIdle;
        
        // Debug
        // velocity = rb.velocity;
        // SpriteRenderer sr = transform.GetChild(1).GetComponent<SpriteRenderer>();
        // sr.color = _isGrounded ? Color.green : Color.red;
    }

    private void FixedUpdate()
    {
        float x;

        if (_isGrounded)
        {
            // calculate horizontal force to apply based on acceleration and input values.
            x = ((movementAcceleration * rb.mass) * _inputHorizontal);

            // adjusting applied horizontal force to match max allowed horizontal velocity.
            x *= ILerp(maxHorizontalVelocity, 0, rb.velocity.x) + .4f;
        }
        else
        {
            // calculate horizontal force to apply based on acceleration and input values.
            x = ((movementAcceleration * rb.mass) * _inputHorizontal) * airSteeringModifier;
            
            // adjusting applied horizontal force to match max allowed horizontal velocity.
            x *= ILerp(maxHorizontalVelocity, 0, rb.velocity.x) + .4f;
        }

        rb.AddForce(new Vector2(x, 0f));

        if (_jump)
        {
            _jump = false;
            rb.AddForce(new Vector2(0f, jumpAcceleration * rb.mass), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }

    private float ILerp(float a, float b, float v)
    {
        return (Mathf.Abs(v) - a) / (b - a);
    }
}
