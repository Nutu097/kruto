using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   private const string _speed = "Speed";
   private const string _movex = "MoveX";
	private const string _movey = "MoveY";
	private const string _idle = "Idle";


	public void RunningAnim(float speed, Vector2 move)
	{
		_animator.SetFloat(_speed, speed);
		_animator.SetFloat(_movex, move.x);
		_animator.SetFloat(_movey, move.y);
	}
}
