using System;
using System.Collections;
using HelperClasses.Event_System;
using HelperClasses.Player_Actions;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class PlayerController : MonoBehaviour
{
    // public Vector2 velocity;
    
    [SerializeField] private int movementAcceleration = 20;
    [SerializeField] private bool useOnlyDefaultMass = true;
    [SerializeField] private int addedJumpAccelerationPerFixedUpdate = 35;
    [SerializeField] private int minJumpAcceleration = 8;
    [SerializeField] private float maxJumpChargeTime = .2f;
	[Space]
    [SerializeField] private float maxHorizontalVelocity = 10;
    [SerializeField] private float frictionCoefficient = 30f;
    [Space]
    [SerializeField, Range(0f, 5f)] private float airSteeringModifier = .2f;
    [Space]
	[SerializeField] private float dashForce = 1000f;
	[SerializeField] private float dashRechargeTime = 2f;
    [Space]
    [SerializeField] private float defaultMass = 80f;
    [SerializeField] private float maximumMass = 150f;
    [SerializeField, Range(0.1f, 2f)] private float massChangeTime = 1f;
    [SerializeField] private Vector2 extraGravity = new Vector2(0f, 0f);
    [Space]

    private GameObject _projectileArrow;
    
    private Rigidbody2D rb;
    private float _inputHorizontal = 0f;
    private float _inputVertical = 0f;

    private bool _jump = false;
    private bool _isGrounded = false;
    private bool _isMoving = false;
	private bool _isAttached = false;

	private bool _canDash = true;

    private bool _hasChangedMass = false;
    private float _targetMass;
    private float _massChangeTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _projectileArrow = transform.Find("ProjectileArrow").gameObject;
        _targetMass = defaultMass;
    }


    void Update()
    {
        _isMoving = _inputHorizontal != 0;

        if (rb.mass != _targetMass)
        {
            ChangeMass();
        }
    }

    private void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        float mass = useOnlyDefaultMass ? defaultMass : rb.mass;
        
        if (_isGrounded)
        {
            // calculate horizontal force to apply based on acceleration and input values.
            force.x = ((movementAcceleration * mass) * _inputHorizontal);

            // adjusting applied horizontal force to match max allowed horizontal velocity.
            force.x *= ILerp(maxHorizontalVelocity, 0, rb.velocity.x) + .4f;
        }
        else
        {
            // calculate horizontal force to apply based on acceleration and input values.
            force.x = ((movementAcceleration * mass) * _inputHorizontal) * airSteeringModifier;
            
            // adjusting applied horizontal force to match max allowed horizontal velocity.
            force.x *= ILerp(maxHorizontalVelocity, 0, rb.velocity.x) + .4f;
        }

        force += extraGravity * rb.mass; // mul by mass to get correct force to apply, because gravity is an acceleration.
        
        Vector2 right = transform.right;
        Vector2 horizontalVelocity = Vector2.Dot(rb.velocity, right) * right;
        
        float facingInputDir = Vector2.Dot(new Vector2(_inputHorizontal, 0f), rb.velocity);

        Vector2 horizontalFriction;
        if (facingInputDir > 0f)
        {
            horizontalFriction = -horizontalVelocity * frictionCoefficient;
        }
        else
        {
            horizontalFriction = -horizontalVelocity * (frictionCoefficient * 10f);
        }

        rb.AddForce(force + horizontalFriction);

        if (_jump)
        {
            rb.AddForce(new Vector2(0f, addedJumpAccelerationPerFixedUpdate * mass), ForceMode2D.Force);
            

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Environment"))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Environment"))
        {
            _isGrounded = false;
        }
    }

    private float ILerp(float a, float b, float v)
    {
        return (Mathf.Abs(v) - a) / (b - a);
    }

    // Input Controllers
    public void SetMovementInput(Vector2 movInput)
    {
        _inputHorizontal = movInput.x;
        _inputVertical = movInput.y;
    }

    public void MassChangeInput(bool shouldStart)
    {
        if (shouldStart)
        {
            _hasChangedMass = true;
            _targetMass = maximumMass;
        }
        else
        {
            _hasChangedMass = false;
            _targetMass = defaultMass;
        }
    }

    private void ChangeMass()
    {
        if (_hasChangedMass)
        {
            _massChangeTimer += Time.deltaTime;

            float newMass = Remap(0f, massChangeTime, defaultMass, maximumMass, _massChangeTimer);
                
            if (newMass > _targetMass)
            {
                newMass = _targetMass;
                _massChangeTimer = massChangeTime;
                rb.mass = newMass;
                return;
            }
                
            rb.mass = newMass;
        }
        else
        {
            _massChangeTimer -= Time.deltaTime;
                
            float newMass = Remap(0f, massChangeTime, defaultMass, maximumMass, _massChangeTimer);
                
            if (newMass < _targetMass)
            {
                newMass = _targetMass;
                _massChangeTimer = 0f;
                rb.mass = newMass;
                return;
            }
                
            rb.mass = newMass;
        }
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _jump = true;
            StartCoroutine(JumpCharge());
        }

		// Will Fire 2 Events , Release from Monkey In Case The player was attached . 
		// And a event of Jumping To whomever wanna listen to that later in the game .
		var monkeyReleaseEvent = new OnPlayerMonkeyBarRelease(gameObject, "Player");
		EventManager.SendNewEvent(monkeyReleaseEvent);
		var playerJumpEvent = new OnPlayerJumpEvent(gameObject, "Player");
		EventManager.SendNewEvent(playerJumpEvent);
	}
    
    public void JumpChargeCanceled()
    {
        _jump = false;
    }
    
    private IEnumerator JumpCharge()
    {
        rb.AddForce(new Vector2(0f, minJumpAcceleration * rb.mass), ForceMode2D.Impulse);
        
        float t = 0f;
        while (t < maxJumpChargeTime && _jump)
        {
            t += Time.deltaTime;
            yield return new WaitForNextFrameUnit();
        }
        _jump = false;
    }

    public void Shoot()
    {
        if (_projectileArrow.activeSelf)
        {
            _projectileArrow.SetActive(false);
            var projectileObj = Instantiate (Resources.Load ("Projectile")) as GameObject;
            if (projectileObj == null) return;
            projectileObj.transform.position = _projectileArrow.transform.position;
            // Will make new Vector3(0.7f,0,0) dynamic later , by getting the x distance from center . Hard coded now just to be fast
            // As designers might not want to reset the Position , So will be deleting that part anyway.
            _projectileArrow.transform.localPosition = new Vector3(0.7f,0,0); 
            _projectileArrow.transform.rotation = Quaternion.Euler(Vector3.zero);
            var projectile = projectileObj.GetComponent<ProjectileScript>();
            if(projectile!=null) projectile.Fire(gameObject);
        }
        else
        {
            _projectileArrow.SetActive(true);
			float distance = Vector2.Distance(transform.position, _projectileArrow.transform.position);
			Vector2 direction = rb.velocity.normalized;
			direction = direction == Vector2.zero ? Vector2.up : direction;
			_projectileArrow.transform.position = transform.position + (Vector3)direction * distance;
        }
    }

	public void Dash()
	{
		if (!_canDash)
			return;
		Vector2 currentDirection = rb.velocity.normalized;
		if (currentDirection == Vector2.zero)
			return;
		rb.AddForce(currentDirection * dashForce, ForceMode2D.Impulse);
		_canDash = false;
		StartCoroutine(RechargeDash());

	}

	public bool GetIsAttached()
	{
		return _isAttached;
	}

	public void SetIsAttached(bool value)
	{
		_isAttached = value;
	}

	private IEnumerator RechargeDash()
	{
		yield return new WaitForSeconds(dashRechargeTime);
		_canDash = true;
	}
	
	private float Remap(float inMin, float inMax, float outMin, float outMax, float v)
    {
        return outMin + ((v - inMin) * (outMax - outMin)) / (inMax - inMin);
    }
}
