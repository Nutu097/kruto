using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

	private Vector2 _moveInput;
	private bool _shiftInput;
	private bool _ctrlInput;
	private PlayerAnimationController _animationController;
	
	[Header("Walking Logic")]

	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;

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
		bool ismoving = _moveInput.sqrMagnitude > 0.1f;
		if(ismoving&&!_shiftInput)
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
	private void Update()
	{
		Move();
		UpdateAnim();
	}
	private void UpdateAnim()
	{ 
		_animationController.RunningAnim(_currentRunSpeed, _moveInput);
	}

	

	
}

