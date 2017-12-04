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

	[Header("Jumping")]
	[SerializeField]
	private float _groundedDistance;
	[SerializeField]
	private float _jumpVelocity;
	[SerializeField]
	private float _jumpCooldown;

	private Rigidbody _rigidbody3d;
	private float _jumpTimer;

	private void Awake()
	{
		_rigidbody3d = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		_rigidbody3d.AddForce(
			NaturalMovement.MatchVelocityForce(
				new Vector3(
					Input.GetAxis("Horizontal"),
					0.0f,
					Input.GetAxis("Vertical")) * _maxVelocity,
				new Vector3(_rigidbody3d.velocity.x, 0.0f, _rigidbody3d.velocity.z),
				_acceleration,
				_maxAcceleration));

		// Jumping
		if (
			Input.GetKeyDown(KeyCode.Space) &&
			_rigidbody3d.velocity.y == 0)
		{
			_rigidbody3d.velocity = new Vector3(_rigidbody3d.velocity.x, _jumpVelocity, _rigidbody3d.velocity.z);
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