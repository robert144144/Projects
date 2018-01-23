using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalMovementPlatforming : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	private float _acceleration;
	[SerializeField]
	private float _maxAcceleration;
	[SerializeField]
	private float _maxVelocity;

	[Header("MoveSpeed")]
	[SerializeField]
	private float _speed;

	[Header("Jumping")]
	[SerializeField]
	private float _groundedDistance;
	[SerializeField]
	private float _jumpVelocity;
	[SerializeField]
	private float _jumpCooldown;
	//[SerializeField]
	//private bool Touching = false;

	private Rigidbody _rigidbody3d;
	private float _jumpTimer;
	private Vector3 goForward = new Vector3(0,0,1);

	private void Awake()
	{
		_rigidbody3d = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		//it works for movement! It moves based on camera facing directions 
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.position = transform.position + Vector3.Scale(Camera.main.transform.forward, goForward) * _speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.position = transform.position - Vector3.Scale(Camera.main.transform.forward, goForward) *  _speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position = transform.position - Camera.main.transform.right * _speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.position = transform.position + Camera.main.transform.right * _speed * Time.deltaTime;
		}
			
//		other moving
//		_rigidbody3d.AddForce(
//			NaturalMovement.MatchVelocityForce(
//				new Vector3(
//					(transform.right * Input.GetAxis("Horizontal")).x,
//					0.0f,
//					(transform.forward * Input.GetAxis("Vertical")).z) * _maxVelocity,
//				new Vector3(_rigidbody3d.velocity.x, 0.0f, _rigidbody3d.velocity.z),
//				_acceleration,
//				_maxAcceleration));

		//if the jump is higher than the max velocity then it equals the max
		if (_rigidbody3d.velocity.y > _maxVelocity) {
			_rigidbody3d.velocity = new Vector3 (_rigidbody3d.velocity.x, _maxVelocity, _rigidbody3d.velocity.z);
		}

		//If the player is floating then give it a small velocity so that the if will detect and prevent it.
		if (_rigidbody3d.velocity.y == 0) {
			_rigidbody3d.velocity = new Vector3 (_rigidbody3d.velocity.x, 0.003f, _rigidbody3d.velocity.z);
		}
		// Jumping Problem now, gravity when 'floating'
		if (Input.GetKeyDown(KeyCode.Space) &&
			_rigidbody3d.velocity.y >= 0 && _rigidbody3d.velocity.y <= 0.01)
		{
			_rigidbody3d.velocity = new Vector3(_rigidbody3d.velocity.x, _jumpVelocity, _rigidbody3d.velocity.z);
		} 
		if (_rigidbody3d.velocity.y > -0.02 && _rigidbody3d.velocity.y <= 0.001) {
			_rigidbody3d.velocity = new Vector3 (_rigidbody3d.velocity.x, 0, _rigidbody3d.velocity.z);
			_rigidbody3d.useGravity = false;
		} else {
			_rigidbody3d.useGravity = true;
			//_rigidbody3d.velocity = new Vector3 (_rigidbody3d.velocity.x, 1, _rigidbody3d.velocity.z);
		}

		// Falling 
		if (_rigidbody3d.velocity.y < 0) {
			_rigidbody3d.velocity += Vector3.up * Physics.gravity.y * 1.5f * Time.deltaTime;
		}
			
	}

	private void FixedUpdate()
	{
		_rigidbody3d.velocity = new Vector3(
			NaturalMovement.CapVelocity(new Vector3(_rigidbody3d.velocity.x, 0.0f, _rigidbody3d.velocity.z), _maxVelocity).x,
			_rigidbody3d.velocity.y, NaturalMovement.CapVelocity(new Vector3(_rigidbody3d.velocity.x, 0.0f, _rigidbody3d.velocity.z), _maxVelocity).z);
	}
}