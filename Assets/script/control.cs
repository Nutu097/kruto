using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _walkSpeed = 2f;
	[SerializeField] private float _runSpeed = 5f;

	private Vector3 _moveVector3;
	


	private bool _isRunning;
	private bool _isSetDown;

	private float cordz;
	private float cordx;
	

	private Vector3 _moveVector;


	[SerializeField] private Transform _shutPoint;
	private float _shutRange = 40f;

	private void Move()
	{
		float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
		/*if (_isRunning )
		{
			currentSpeed = _runSpeed;
		}
		else if (!_isRunning)
		{
			currentSpeed = _walkSpeed;
		}*/
		_moveVector3 = transform.forward * cordz;
		if (_moveVector3.magnitude > 1f)
		{
			_moveVector3.Normalize();
		}
		_moveVector3 *= currentSpeed * Time.deltaTime;
		_rigidbody.MovePosition(_moveVector3 + _rigidbody.position);

		/*if (animator != null)
		{
			bool isMoving = cordx != 0 || cordz != 0;

			animator.SetBool("run", isMoving && _isRunning);
		}*/

	}
	private void OnEnable()
	{

		my_input_manger.OnMovePressed += ReadMoveInput;
		
		
		{
			
		}
		
	}
	private void OnDisable()
	{
		my_input_manger.OnMovePressed -= ReadMoveInput;
		

	}
	private void ReadMoveInput(Vector2 inputVector)

	{
		cordz = inputVector.y;
		cordx = inputVector.x;
	}
	private void Update()
	{
		Move();
	}
}
