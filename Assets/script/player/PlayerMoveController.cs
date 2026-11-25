using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMoveController : MonoBehaviour
{

	private Vector2 _moveInput;
	private bool _shiftInput;
	private bool _ctrlInput;
	private bool _isJumpQeued;
	private bool _isGrounded;
	private float _looInputX;
	private PlayerAnimationController _animationController;
	[SerializeField] private float _newRotaion;
	[Header("Walking Logic")]

	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _speedRotationSpeed = 5f;
	private float _currentRunSpeed;

	public void GetMoveInput(Vector2 input)
	{
		_moveInput = input;
	}
	public void Initialize(PlayerAnimationController a)
	{
		_animationController = a;
	}
	
	public void GetShiftInput(bool isPressed)
	{
		_shiftInput = isPressed;
	}
	public void Move()
	{
		Vector3 moveX =( _moveInput.x * transform.right +
		_moveInput.y * transform.forward )* _currentRunSpeed * Time.fixedDeltaTime;
	
		float moveY = _rb.linearVelocity.y;
		if (_isJumpQeued && _isGrounded)
		{
			moveY = _jumpForce;
			_isJumpQeued = false;
			
		}
		Vector3 linearVelocity = new Vector3(0, moveY, 0)+ moveX ;
		_rb.linearVelocity = linearVelocity ;
		
	}
	public void GetGraundInfo(bool T)
	{
		_isGrounded = T;
		
		if (!_isGrounded)
		{
			_isJumpQeued = false;
		}
	}
	public void GetSpaceInput()
	{
		//_rb.AddForce(new Vector3(0f, _jumpForce, 0f), ForceMode.Impulse);
		//_rb.linearVelocity = new Vector3(0f, _jumpForce, 0f);
		_isJumpQeued = true;
	}
	public void GetLookInput(Vector2 input)
	{
		if (input.sqrMagnitude < 0.1f)
		{
			_looInputX = 0f;
			return;
		} 
		
		_looInputX = input.x;

	}
	private void CalculatePlayerSpeed()
	{
		bool ismoving = _moveInput.sqrMagnitude > 0.1f;
		if (ismoving && !_shiftInput)
		{
			_currentRunSpeed = _runSpeed;

		}
		else if
		(ismoving && _shiftInput)
		{
			_currentRunSpeed = _walkSpeed;
		}
		else
		{
			_currentRunSpeed = 0f;
		}
	}
	private void Rotateplayer()
	{
		_newRotaion += _looInputX * _speedRotationSpeed * Time.deltaTime;
		//_newRotation.y = (_looInputX * _speedRotationSpeed) + _newRotation.y;
		transform.localRotation = Quaternion.Euler(0f, _newRotaion,0f);
	}
	private void FixedUpdate()
	{
		Move();
	}
	private void Update()
	{
		Rotateplayer();
		UpdateAnim();
		CalculatePlayerSpeed();
	}
	private void UpdateAnim()
	{ 
		_animationController.RunningAnim(_currentRunSpeed, _moveInput);
	}

}

